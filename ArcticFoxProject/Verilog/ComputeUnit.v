/*
Copyright (c) 2022, Icii Technologies LLC
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

module ComputeUnit(

);


/*[Set]*/ parameter dataSampleWidth = 16;
/*[Set]*/ parameter resultWidth = 32;

//[.ScalableTop dataSample_{ComputeUnitNumber}]
wire [dataSampleWidth - 1:0] dataSample;

reg [resultWidth - 1:0] result;
always@(posedge clk) begin
    if(reset)
        result <= 0;
    else
        result <= dataSample << 2;
end


endmodule
