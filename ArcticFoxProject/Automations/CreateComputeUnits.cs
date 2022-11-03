/*
Copyright (c) 2022, Icii Technologies LLC
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

using ArcticFox.Automations;
using LiveDemo_ScalableCommon;

namespace LiveDemo_Scalable;

public class CreateComputeUnits : VerilogAutomation
{
    protected override Dependencies Dependencies => Values.Get("coreCount");

	protected override void ApplyAutomation()
	{
		int coreCount = Values.Get("coreCount");

		for(int i = 1; i <= coreCount; i++)
			CodeAfterAutomation += @$"
//[Property ComputeUnitNumber {i}]
ComputeUnit computeUnit{i} (
);";
	}
}