/*
Copyright (c) 2022, Icii Technologies LLC
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArcticFox.Automations;

namespace LiveDemo_Scalable;

public class ResultsBinaryAdderTree : VerilogAutomation
{
    protected override Dependencies Dependencies => Values.Get("coreCount");

	protected override void ApplyAutomation()
	{
		int coreCount = Values.Get("coreCount");

		if(coreCount == 0)
			return;

		List<string> computeUnitResults = new List<string>();
		
		for(int i = 1; i <= coreCount; i++)
		{
			computeUnitResults.Add($"results{i}");
		}

		string binaryAdderTree = GenerateBinaryAdderTree(computeUnitResults);
		CodeAfterAutomation += binaryAdderTree;
	}

	public string GenerateBinaryAdderTree(List<string> signals)
	{

		string[] previousSignals = new string[signals.Count];
		signals.CopyTo(previousSignals);
		List<string> resultWires = previousSignals.ToList();
		List<string> previousResults = new List<string>();
		int index = 0;

		StringBuilder code = new StringBuilder();

		do
		{
			previousSignals = new string[resultWires.Count];
			resultWires.CopyTo(previousSignals);
			previousResults = previousSignals.ToList();
			resultWires = new List<string>();

			for (int i = 0; i < previousResults.Count; i += 2)
			{
				string wireName = $"adderResult_{index}_{i}_{i + 1}";
				resultWires.Add(wireName);

				if (i == previousResults.Count - 1)
				{
					code.Append($@"
reg [resultWidth - 1:0] {wireName};
always@(posedge clk) begin
    if(reset)
        {wireName} <= 0;
    else
        {wireName} <= {previousResults[i]};
end
");
				}
				else
				{
					code.Append($@"
reg [resultWidth - 1:0] {wireName};
always@(posedge clk) begin
if(reset)
	{wireName} <= 0;
else
	{wireName} <= {previousResults[i]} + {previousResults[i + 1]};
end
");
				}
			}

			index++;
		} while (resultWires.Count > 1);

		string resultWireName = $"binaryAdderTreeResult";
		code.Append($@"
wire [resultWidth - 1:0] {resultWireName};
assign {resultWireName} = {resultWires[0]};
");

		return code.ToString();

    }
}