/*
Copyright (c) 2022, Icii Technologies LLC
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

//[TopLevel]
//[$coreCount 4]
//[$dataSampleWidth 16]
//[$resultWidth 32]
//[AddToAllExceptThis Common]
module ScalableTop(
    //[Common]
    //[Clock 100MHz]
    input clk,

    //[Common]
    //[Reset]
    input reset,

    //[Branch $coreCount]
    input [dataSampleWidth - 1:0] dataSample
);




/*[Set]*/ parameter dataSampleWidth = 16;
/*[Set]*/ parameter coreCount = 4;

reg myReg;
//[Previous]
reg p1_myReg;

//[CreateComputeUnits]

//[GatherResults]

//[ResultsBinaryAdderTree]

wire otherWire;


endmodule
