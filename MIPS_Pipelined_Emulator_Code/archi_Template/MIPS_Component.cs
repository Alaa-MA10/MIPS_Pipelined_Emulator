using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archi_Template
{
     class MIPS_Component
     {
         
          public void instruction_memory(uint PC, string instruction)
          {
               MIPS.instruct_mem.Add(PC, instruction);
               MIPS.qFetch.Enqueue(PC);
          }

          public string Control_Unit(string Op_Code)
          {
               string WE, M, EX;
               if (Op_Code.Equals("000000"))   // R-Type 
               {
                    WE = "10";
                    M = "000";
                    EX = "1100";
               }
               else if(Op_Code.Equals("100011"))   // I-Type  LW
               {
                    WE = "11";
                    M = "010";
                    EX = "0001";
               }
               else if (Op_Code.Equals("101011"))   // I-Type SW
               {
                    WE = "0X";
                    M = "001";
                    EX = "X001";
               }
               else
               {
                    WE = "0X";
                    M = "100";
                    EX = "X010";
               }

               return WE + "#" + M + "#" + EX;
          }

          public string Regiter_file(string Read_Reg1, string Read_Reg2, string Write_Reg, string Write_Data, char RegWrite_Sel)
          {
               if (RegWrite_Sel.Equals('0'))    //Read from Register 
               {
                    int Reg1 = Convert.ToInt32(Read_Reg1,2);    // From Binary to decimal
                    int Reg2 = Convert.ToInt32(Read_Reg2, 2);
                    string Read_data1 = MIPS.Register[Reg1].ToString();
                    string Read_data2 = MIPS.Register[Reg2].ToString();
                    return Read_data1 + "#" + Read_data2;
               }
               else         // Write To Register
               {
                    int Reg = Convert.ToInt32(Write_Reg,2);
                    MIPS.Register[Reg] = int.Parse(Write_Data);
                    return "-1";
               }
          }

          public string MUX(string I0, string I1, char Selector)
          {
               if (Selector.Equals('1'))
                    return I1;
               else
                    return I0;
          }

          public string Adder(string data1, string data2)
          {
               return (int.Parse(data1) + int.Parse(data2)).ToString();
          }

          public string sign_extend(string Address)
          {
               char msign = Address[0];
               string extend = "";
               for (int i = 0; i < 16; i++)
                    extend += msign;

               return extend + Address;
          }

          public string ALU(string data1, string data2, string Alu_op, string funct)
          {
               string ZeroFlag = "0";
               int res;

               if (Alu_op.Equals("00"))  //LW & SW
               {
                    res = int.Parse(data1) + int.Parse(data2);
               }

               else if(Alu_op.Equals("01"))   // beq
               {
                    res = int.Parse(data1) - int.Parse(data2);
               }

               else   // R-Type
               {
                    if(funct.Equals("100000"))  // Add
                    {
                         res = int.Parse(data1) + int.Parse(data2);
                    }
                    else if (funct.Equals("100010"))  // Sub
                    {
                         res = int.Parse(data1) - int.Parse(data2);
                    }
                    else if (funct.Equals("100100"))  // And
                    {
                         res = int.Parse(data1) & int.Parse(data2);
                    }
                    else   //Or
                    {
                         res = int.Parse(data1) | int.Parse(data2);
                    }
               }

               if (res == 0)
                    ZeroFlag = "1";
               return ZeroFlag + "#" + res.ToString();//Convert.ToString(res,2);
          }

          public string ShiftL(string Address)
          {
               return (Convert.ToInt32(Address, 2) * 4).ToString();
          }

          public string data_memory(string Address, string Write_data, char Mem_Write, char Mem_Read)
          {
                return "-1";
          }

          public char Branch(char BranchStat, string ZeroFlag)
          {
               if (BranchStat == '1' && ZeroFlag == "1")
                    return '1';
               return '0';
          }
     }
}
