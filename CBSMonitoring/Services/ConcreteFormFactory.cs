using CBSMonitoring.Constants;
using CBSMonitoring.DTOs.FormDtos;
using CBSMonitoring.Models.Forms;

namespace CBSMonitoring.Services
{
    public class ConcreteFormFactory : FormFactory
    {

        public override Type[] GetMonitoringForm(string formNumber, int argCount)
            => formNumber switch
            {
                FormType.Form1_1_1 => argCount == 1
                    ? new Type[] { typeof(Form1_1_1) }
                    : new Type[] { typeof(Form1_1_1), typeof(Form1_1_1Dto) },
                FormType.Form1_1_2 => argCount == 1
                    ? new Type[] { typeof(Form1_1_2) }
                    : new Type[] { typeof(Form1_1_2), typeof(Form1_1_2Dto) },
                FormType.Form1_1_3 => argCount == 1
                    ? new Type[] { typeof(Form1_1_3) }
                    : new Type[] { typeof(Form1_1_3), typeof(Form1_1_3Dto) },
                FormType.Form1_1_4 => argCount == 1
                    ? new Type[] { typeof(Form1_1_4) }
                    : new Type[] { typeof(Form1_1_4), typeof(Form1_1_4Dto) },
                FormType.Form1_1_5 => argCount == 1 
                    ? new Type[] { typeof(Form1_1_5) } 
                    : new Type[] { typeof(Form1_1_5), typeof(Form1_1_5Dto) },
                FormType.Form1_1_6 => argCount == 1 
                    ? new Type[] { typeof(Form1_1_6) } 
                    : new Type[] { typeof(Form1_1_6), typeof(Form1_1_6Dto) },
                FormType.Form1_2_1 => argCount == 1 
                    ? new Type[] { typeof(Form1_2_1) } 
                    : new Type[] { typeof(Form1_2_1), typeof(Form1_2_1Dto) },
                FormType.Form1_3_1 => argCount == 1 
                    ? new Type[] { typeof(Form1_3_1) } 
                    : new Type[] { typeof(Form1_3_1), typeof(Form1_3_1Dto) },
                FormType.Form1_4_1 => argCount == 1 
                    ? new Type[] { typeof(Form1_4_1) } 
                    : new Type[] { typeof(Form1_4_1), typeof(Form1_4_1Dto) },
                FormType.Form1_4_2 => argCount == 1 
                    ? new Type[] { typeof(Form1_4_2) } 
                    : new Type[] { typeof(Form1_4_2), typeof(Form1_4_2Dto) },
                FormType.Form1_4_3 => argCount == 1 
                    ? new Type[] { typeof(Form1_4_3) } 
                    : new Type[] { typeof(Form1_4_3), typeof(Form1_4_3Dto) },
                FormType.Form1_4_4 => argCount == 1 
                    ? new Type[] { typeof(Form1_4_4) } 
                    : new Type[] { typeof(Form1_4_4), typeof(Form1_4_4Dto) },
                FormType.Form1_5_1 => argCount == 1 
                    ? new Type[] { typeof(Form1_5_1) } 
                    : new Type[] { typeof(Form1_5_1), typeof(Form1_5_1Dto) },
                FormType.Form1_5_2 => argCount == 1 
                    ? new Type[] { typeof(Form1_5_2) } 
                    : new Type[] { typeof(Form1_5_2), typeof(Form1_5_2Dto) },
                FormType.Form1_5_3 => argCount == 1 
                    ? new Type[] { typeof(Form1_5_3) } 
                    : new Type[] { typeof(Form1_5_3), typeof(Form1_5_3Dto) },
                FormType.Form2_1_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_1_1) } 
                    : new Type[] { typeof(Form2_1_1), typeof(Form2_1_1Dto) },
                FormType.Form2_1_2 => argCount == 1 
                    ? new Type[] { typeof(Form2_1_2) } 
                    : new Type[] { typeof(Form2_1_2), typeof(Form2_1_2Dto) },
                FormType.Form2_2_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_2_1) } 
                        : new Type[] { typeof(Form2_2_1), typeof(Form2_2_1Dto) },
                FormType.Form2_2_2 => argCount == 1 
                    ? new Type[] { typeof(Form2_2_2) } 
                    : new Type[] { typeof(Form2_2_2), typeof(Form2_2_2Dto) },
                FormType.Form2_3_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_3_1) } 
                    : new Type[] { typeof(Form2_3_1), typeof(Form2_3_1Dto) },
                FormType.Form2_3_2 => argCount == 1 
                    ? new Type[] { typeof(Form2_3_2) } 
                    : new Type[] { typeof(Form2_3_2), typeof(Form2_3_2Dto) },
                FormType.Form2_3_3 => argCount == 1 
                    ? new Type[] { typeof(Form2_3_3) } 
                    : new Type[] { typeof(Form2_3_3), typeof(Form2_3_3Dto) },
                FormType.Form2_3_4 => argCount == 1 
                    ? new Type[] { typeof(Form2_3_4) } 
                    : new Type[] { typeof(Form2_3_4), typeof(Form2_3_4Dto) },
                FormType.Form2_4_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_4_1) } 
                    : new Type[] { typeof(Form2_4_1), typeof(Form2_4_1Dto) },
                FormType.Form2_4_2 => argCount == 1 
                    ? new Type[] { typeof(Form2_4_2) } 
                    : new Type[] { typeof(Form2_4_2), typeof(Form2_4_2Dto) },
                FormType.Form2_4_3 => argCount == 1 
                    ? new Type[] { typeof(Form2_4_3) } 
                    : new Type[] { typeof(Form2_4_3), typeof(Form2_4_3Dto) },
                FormType.Form2_5_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_5_1) } 
                    : new Type[] { typeof(Form2_5_1), typeof(Form2_5_1Dto) },
                FormType.Form2_6_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_6_1) } 
                    : new Type[] { typeof(Form2_6_1), typeof(Form2_6_1Dto) },
                FormType.Form2_7_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_7_1) } 
                    : new Type[] { typeof(Form2_7_1), typeof(Form2_7_1Dto) },
                FormType.Form2_8_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_8_1) } 
                    : new Type[] { typeof(Form2_8_1), typeof(Form2_8_1Dto) },
                FormType.Form2_9_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_9_1) } 
                    : new Type[] { typeof(Form2_9_1), typeof(Form2_9_1Dto) },
                FormType.Form2_10_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_10_1) } 
                    : new Type[] { typeof(Form2_10_1), typeof(Form2_10_1Dto) },
                FormType.Form2_11_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_11_1) } 
                    : new Type[] { typeof(Form2_11_1), typeof(Form2_11_1Dto) },
                FormType.Form2_11_2 => argCount == 1 
                    ? new Type[] { typeof(Form2_11_2) } 
                    : new Type[] { typeof(Form2_11_2), typeof(Form2_11_2Dto) },
                FormType.Form2_11_3 => argCount == 1 
                    ? new Type[] { typeof(Form2_11_3) } 
                    : new Type[] { typeof(Form2_11_3), typeof(Form2_11_3Dto) },
                FormType.Form2_11_4 => argCount == 1 
                    ? new Type[] { typeof(Form2_11_4) } 
                    : new Type[] { typeof(Form2_11_4), typeof(Form2_11_4Dto) },
                FormType.Form2_11_5 => argCount == 1 
                    ? new Type[] { typeof(Form2_11_5) } 
                    : new Type[] { typeof(Form2_11_5), typeof(Form2_11_5Dto) },
                FormType.Form2_11_6 => argCount == 1 
                    ? new Type[] { typeof(Form2_11_6) } 
                    : new Type[] { typeof(Form2_11_6), typeof(Form2_11_6Dto) },
                FormType.Form2_11_7 => argCount == 1 
                    ? new Type[] { typeof(Form2_11_7) } 
                    : new Type[] { typeof(Form2_11_7), typeof(Form2_11_7Dto) },
                FormType.Form2_12_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_12_1) } 
                    : new Type[] { typeof(Form2_12_1), typeof(Form2_12_1Dto) },
                FormType.Form2_13_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_13_1) } 
                    : new Type[] { typeof(Form2_13_1), typeof(Form2_13_1Dto) },
                FormType.Form2_14_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_14_1) } 
                    : new Type[] { typeof(Form2_14_1), typeof(Form2_14_1Dto) },
                FormType.Form2_15_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_15_1) } 
                    : new Type[] { typeof(Form2_15_1), typeof(Form2_15_1Dto) },
                FormType.Form2_16_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_16_1) } 
                    : new Type[] { typeof(Form2_16_1), typeof(Form2_16_1Dto) },
                FormType.Form2_17_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_17_1) } 
                    : new Type[] { typeof(Form2_17_1), typeof(Form2_17_1Dto) },
                FormType.Form2_18_1 => argCount == 1 
                    ? new Type[] { typeof(Form2_18_1) } 
                    : new Type[] { typeof(Form2_18_1), typeof(Form2_18_1Dto) },
                FormType.Form3_1_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_1_1) } 
                    : new Type[] { typeof(Form3_1_1), typeof(Form3_1_1Dto) },
                FormType.Form3_1_2 => argCount == 1 
                    ? new Type[] { typeof(Form3_1_2) } 
                    : new Type[] { typeof(Form3_1_2), typeof(Form3_1_2Dto) },
                FormType.Form3_2_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_2_1) } 
                    : new Type[] { typeof(Form3_2_1), typeof(Form3_2_1Dto) },
                FormType.Form3_2_2 => argCount == 1 
                    ? new Type[] { typeof(Form3_2_2) } 
                    : new Type[] { typeof(Form3_2_2), typeof(Form3_2_2Dto) },
                FormType.Form3_3_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_3_1) } 
                    : new Type[] { typeof(Form3_3_1), typeof(Form3_3_1Dto) },
                FormType.Form3_4_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_4_1) } 
                    : new Type[] { typeof(Form3_4_1), typeof(Form3_4_1Dto) },
                FormType.Form3_5_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_5_1) } 
                    : new Type[] { typeof(Form3_5_1), typeof(Form3_5_1Dto) },
                FormType.Form3_6_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_6_1) } 
                    : new Type[] { typeof(Form3_6_1), typeof(Form3_6_1Dto) },
                FormType.Form3_7_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_7_1) } 
                    : new Type[] { typeof(Form3_7_1), typeof(Form3_7_1Dto) },
                FormType.Form3_8_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_8_1) } 
                    : new Type[] { typeof(Form3_8_1), typeof(Form3_8_1Dto) },
                FormType.Form3_9_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_9_1) } 
                    : new Type[] { typeof(Form3_9_1), typeof(Form3_9_1Dto) },
                FormType.Form3_10_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_10_1) } 
                    : new Type[] { typeof(Form3_10_1), typeof(Form3_10_1Dto) },
                FormType.Form3_11_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_11_1) } 
                    : new Type[] { typeof(Form3_11_1), typeof(Form3_11_1Dto) },
                FormType.Form3_12_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_12_1) } 
                    : new Type[] { typeof(Form3_12_1), typeof(Form3_12_1Dto) },
                FormType.Form3_13_1 => argCount == 1 
                    ? new Type[] { typeof(Form3_13_1) } 
                    : new Type[] { typeof(Form3_13_1), typeof(Form3_13_1Dto) },

                _ => throw new NotSupportedException($"Form number {formNumber} is not supported.")

            };

    }
}
