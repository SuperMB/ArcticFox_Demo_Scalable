/*
Copyright (c) 2022, Icii Technologies LLC
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

using ArcticFox.Automations;

namespace LiveDemo_Scalable;

public class GatherResults : VerilogAutomation
{
    protected override Dependencies Dependencies => Values.Get("coreCount");

	protected override void ApplyAutomation()
	{
		int coreCount = Values.Get("coreCount");

		for(int i = 1; i <= coreCount; i++)
			CodeAfterAutomation += @$"
//[.computeUnit{i} result]
wire [resultWidth - 1:0] result{i};";
	}
}