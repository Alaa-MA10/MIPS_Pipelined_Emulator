using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archi_Template
{
     class Pipeline_Stages
     {
          MIPS_Component mips_comp = new MIPS_Component();

          public void Fetch(string Address_instr)
          {
               string[] instr_part = Address_instr.Split(':');  // split Read_address, instruction[31-0]
               string Read_address = instr_part[0],
                      instr31_0 = instr_part[1],
                      Adder_Res;

               if (Read_address == MIPS.PC_Reg)   // check current instruction will Execute
               {
                    mips_comp.instruction_memory(Convert.ToUInt32(Read_address), instr31_0);
               }
               
               Adder_Res = mips_comp.Adder(MIPS.PC_Reg, "4");    // move to next Instruction
               MIPS.PC_Reg = mips_comp.MUX(Adder_Res, MIPS.Beq_PC, MIPS.PCSrc);
               MIPS.PCSrc = '0';
               MIPS.IF_IDReg = Adder_Res + "#" + instr31_0;    // save in IF/ID pipeline_Reg
          }

          public void Decode()
          {
               string[] IF_IDData = MIPS.IF_IDReg.Split('#');
               if (IF_IDData[0].Equals(""))
                    return;
               string PC_Address = IF_IDData[0],
                      instruction = IF_IDData[1];

               string[] instr_part = instruction_divide(instruction).Split('#');
               string Op_Code = instr_part[0],
                      rs = instr_part[1],
                      rt = instr_part[2];

               string[] readData = mips_comp.Regiter_file(rs, rt, "X", "X", '0').Split('#');
               string readData1 = readData[0],
                      readData2 = readData[1],
                      instr15_0 = instr_part[3],
                      instr20_16 = instr_part[2],
                      instr15_11 = instr_part[3].Substring(0,5),
                      extend_address;
                
               if (Op_Code.Equals("000000"))
               {
                    instr15_0 += instr_part[4] + instr_part[5];
                    extend_address = mips_comp.sign_extend(instr15_0);
               }
               else
               {
                    extend_address = mips_comp.sign_extend(instr15_0);
               }

               MIPS.ID_EXReg = mips_comp.Control_Unit(Op_Code) + "#" + PC_Address + "#" + readData1 + "#" +
                               readData2 + "#" + extend_address + "#" + instr20_16 + "#" + instr15_11;
          }

          public void Execute()
          {
               string[] ID_EXData = MIPS.ID_EXReg.Split('#');
               if (ID_EXData[0].Equals(""))
                    return;

               string WB = ID_EXData[0],
                      M = ID_EXData[1],
                      EX = ID_EXData[2],
                      ALUOp = EX.Substring(1, 2),
                      PC_address = ID_EXData[3],
                      Read_data1 = ID_EXData[4],
                      Read_data2 = ID_EXData[5],
                      extend_address = ID_EXData[6],
                      ALU_funct = extend_address.Substring(26, 6),
                      instr20_16 = ID_EXData[7],
                      instr15_11 = ID_EXData[8],
                      data2, Alu_res, Adder_Res, Mux_res;

               char ALUSrc = EX[3],
                    RegDst = EX[0];
               data2 = mips_comp.MUX(Read_data2, extend_address, ALUSrc);  // Select Data2 to ALU
               Alu_res = mips_comp.ALU(Read_data1, data2, ALUOp, ALU_funct);
               Adder_Res = mips_comp.Adder(PC_address, mips_comp.ShiftL(extend_address));  // calc. Address
               Mux_res = mips_comp.MUX(instr20_16, instr15_11, RegDst);

               MIPS.EX_MEMReg = WB + "#" + M + "#" + Adder_Res + "#" + Alu_res + "#" + Read_data2 + "#" + Mux_res;
          }

          public void Memory_Access()
          {
               string[] EX_MEMData = MIPS.EX_MEMReg.Split('#');
               string WB = EX_MEMData[0],
                      M = EX_MEMData[1],
                      PC_address = EX_MEMData[2],
                      ALU_zero = EX_MEMData[3],
                      Alu_res = EX_MEMData[4],
                      Write_data = EX_MEMData[5],
                      RegDst_res = EX_MEMData[6],
                      Read_data;

               char Branch_stat = M[0], 
                    MemRead = M[1], 
                    MemWrite = M[2],
                    Branch_res;

               Branch_res = mips_comp.Branch(Branch_stat, ALU_zero);
               if (Branch_res == '1')  // Execute Branch
               {
                    MIPS.Beq_PC = PC_address;
                    MIPS.PCSrc = Branch_res;

                    MIPS.IF_IDReg = "";
                    MIPS.ID_EXReg = "";
                    MIPS.EX_MEMReg = "";
               }

               Read_data = mips_comp.data_memory(Alu_res, Write_data, MemWrite, MemRead);

               MIPS.MEM_WBReg = WB + "#" + Read_data + "#" + Alu_res + "#" + RegDst_res;
          }

          public void Write_Back()
          {
               string[] MEM_WBData = MIPS.MEM_WBReg.Split('#');
               string WB = MEM_WBData[0],
                      Read_data = MEM_WBData[1],
                      Alu_res = MEM_WBData[2],
                      RegDst = MEM_WBData[3],
                      Mux_res;

               char MemToReg = WB[1],
                    RegWrite = WB[0];

               Mux_res = mips_comp.MUX(Alu_res, Read_data, MemToReg);

               if(RegWrite == '1')
                    mips_comp.Regiter_file("X", "X", RegDst, Mux_res, RegWrite);

          }


          string instruction_divide(string instruction)
          {
               instruction = instruction.Replace(" ", "");
               string Op_code = instruction.Substring(0, 6);
               string rs = instruction.Substring(6, 5);
               string rt = instruction.Substring(11, 5);

               if(Op_code.Equals("000000")) // R-Type
               {
                    string rd = instruction.Substring(16, 5);
                    string shamt = instruction.Substring(21, 5);
                    string funct = instruction.Substring(26, 6);
                    return Op_code + "#" + rs + "#" + rt + "#" + rd + "#" + shamt + "#" + funct;
               }
               else   //I-Type
               {
                    string address = instruction.Substring(16, 16);
                    return Op_code + "#" + rs + "#" + rt + "#" + address;
               }
          }
     }
}
