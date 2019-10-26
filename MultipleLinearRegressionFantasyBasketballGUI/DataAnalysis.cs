using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
namespace FantasyBasketballDataAnalysis
{
    public class DataAnalysis
    {
        public static List<float> y_list = new List<float>(); public static List<float> x0_list = new List<float>(); //this list is only 1's always
        public static List<float> x1_list = new List<float>(); public static List<float> x2_list = new List<float>(); public static List<float> x3_list = new List<float>();
        public static List<float> x4_list = new List<float>(); public static List<float> x5_list = new List<float>(); public static List<float> x6_list = new List<float>();
        public static List<float> x7_list = new List<float>(); public static List<float> x8_list = new List<float>(); public static List<float> x9_list = new List<float>();
        public static List<float> y_list_unsorted = new List<float>(); 
        public static List<float> x1_list_unsorted = new List<float>(); public static List<float> x2_list_unsorted = new List<float>(); public static List<float> x3_list_unsorted = new List<float>();
        public static List<float> x4_list_unsorted = new List<float>(); public static List<float> x5_list_unsorted = new List<float>(); public static List<float> x6_list_unsorted = new List<float>();
        public static List<float> x7_list_unsorted = new List<float>(); public static List<float> x8_list_unsorted = new List<float>(); public static List<float> x9_list_unsorted = new List<float>();
        public static List<string> Regressors;
        public static string DataFileName_X_Transpose_X_Matrix, DataFileName_X_Transpose_X_Matrix_Inverse, InitialDirectory, DataDirectory, FullDataFileName, end_datafilename, GnuplotTemplateDirectory, TemplateDirectory;   
        public static float[,] C, X_Transpose_X_Matrix, X_Transpose_X_Inverse_Matrix;
        public static float[] D, E, Beta_Matrix, X_Transpose_Y_Matrix;
        public static string[] Regressor_Name, CategoryName;
        public static double SSR, SST, SSE, DF_Regression, DF_Error, DF_Total, Mean_Square_Regression, Mean_Square_Error, SigmaSquared, F_Statistic, RSquared, RSquaredAdjusted;
        public DataAnalysis(string DataDirectory, string FullDataFileName, string TemplateDirectory)
        {
            List<float>[] ArrayOfLists_no_x0_Sorted = new List<float>[] { y_list, x1_list, x2_list, x3_list, x4_list, x5_list, x6_list, x7_list, x8_list, x9_list };
            List<float>[] ArrayOfLists_no_X0_UNSORTED = new List<float>[] {y_list_unsorted, x1_list_unsorted, x2_list_unsorted, x3_list_unsorted, x4_list_unsorted, x5_list_unsorted, x6_list_unsorted, x7_list_unsorted, x8_list_unsorted, x9_list_unsorted };
            InitialDirectory = DataDirectory;
            GnuplotTemplateDirectory = TemplateDirectory;
            end_datafilename = FullDataFileName.Substring(DataDirectory.Length, FullDataFileName.Length - DataDirectory.Length);
            string[] DataFileNameContent = File.ReadAllLines(FullDataFileName);
            int headerLinePosition = 1;
            long NumDataPoints = DataFileNameContent.Length - headerLinePosition;
            string[] SplitData;
            string x0_str = "x0", x1_str = "x1", x2_str = "x2", x3_str = "x3", x4_str = "x4", x5_str = "x5", x6_str = "x6", x7_str = "x7", x8_str = "x8", x9_str = "x9";  //must add to 9 for 9 CATEGORIES
            Regressors = new List<string>();  //must add 9 for 9 CATEGORIES
            string[] Regressors_Array = new string[] { x0_str, x1_str, x2_str, x3_str, x4_str, x5_str, x6_str, x7_str, x8_str, x9_str };
            for (int i = 0; i < Regressors_Array.Length; i++)
            {
                Regressors.Add(Regressors_Array[i]);
            }
            C = new float[Regressors.Count, Regressors.Count];
            D = new float[Regressors.Count];
            E = new float[Regressors.Count];
            int x0_index = Regressors.IndexOf(x0_str), x1_index = Regressors.IndexOf(x1_str), x2_index = Regressors.IndexOf(x2_str), x3_index = Regressors.IndexOf(x3_str);
            int x4_index = Regressors.IndexOf(x4_str), x5_index = Regressors.IndexOf(x5_str), x6_index = Regressors.IndexOf(x6_str);
            int x7_index = Regressors.IndexOf(x7_str), x8_index = Regressors.IndexOf(x8_str), x9_index = Regressors.IndexOf(x9_str);
            int y = 1, x0 = 2, x1 = 3, x2 = 4, x3 = 5, x4 = 6, x5 = 7, x6 = 8, x7 = 9, x8 = 10, x9 = 11;  //must add 9 for 9 CATEGORIES
            float[] Y_Matrix = new float[NumDataPoints];
            float[,] X_Matrix = new float[NumDataPoints, Regressors.Count];
            Beta_Matrix = new float[Regressors.Count];
            double y_listSum = 0, x1_listSum = 0, x2_listSum = 0, x3_listSum = 0, 
                   x4_listSum = 0, x5_listSum = 0, x6_listSum = 0, 
                   x7_listSum = 0, x8_listSum = 0, x9_listSum = 0;
            for (int i = 0; i < NumDataPoints; i++)
            {
                SplitData = DataFileNameContent[i + headerLinePosition].Split(',');
                y_list.Add(float.Parse(SplitData[y]));
                x0_list.Add(float.Parse(SplitData[x0]));
                x1_list.Add(float.Parse(SplitData[x1]));
                x2_list.Add(float.Parse(SplitData[x2]));
                x3_list.Add(float.Parse(SplitData[x3]));
                x4_list.Add(float.Parse(SplitData[x4]));
                x5_list.Add(float.Parse(SplitData[x5]));
                x6_list.Add(float.Parse(SplitData[x6]));
                x7_list.Add(float.Parse(SplitData[x7]));
                x8_list.Add(float.Parse(SplitData[x8]));
                x9_list.Add(float.Parse(SplitData[x9]));
                y_list_unsorted.Add(float.Parse(SplitData[y]));
                x1_list_unsorted.Add(float.Parse(SplitData[x1]));
                x2_list_unsorted.Add(float.Parse(SplitData[x2]));
                x3_list_unsorted.Add(float.Parse(SplitData[x3]));
                x4_list_unsorted.Add(float.Parse(SplitData[x4]));
                x5_list_unsorted.Add(float.Parse(SplitData[x5]));
                x6_list_unsorted.Add(float.Parse(SplitData[x6]));
                x7_list_unsorted.Add(float.Parse(SplitData[x7]));
                x8_list_unsorted.Add(float.Parse(SplitData[x8]));
                x9_list_unsorted.Add(float.Parse(SplitData[x9]));
                Y_Matrix[i] = y_list[i];
                X_Matrix[i, x0_index] = x0_list[i];
                X_Matrix[i, x1_index] = x1_list[i];
                X_Matrix[i, x2_index] = x2_list[i];
                X_Matrix[i, x3_index] = x3_list[i];
                X_Matrix[i, x4_index] = x4_list[i];
                X_Matrix[i, x5_index] = x5_list[i];
                X_Matrix[i, x6_index] = x6_list[i];
                X_Matrix[i, x7_index] = x7_list[i];
                X_Matrix[i, x8_index] = x8_list[i];
                X_Matrix[i, x9_index] = x9_list[i];
                y_listSum += Double.Parse(y_list[i].ToString());
                x1_listSum += Double.Parse(x1_list[i].ToString());
                x2_listSum += Double.Parse(x2_list[i].ToString());               
                x3_listSum += Double.Parse(x3_list[i].ToString());
                x4_listSum += Double.Parse(x4_list[i].ToString());
                x5_listSum += Double.Parse(x5_list[i].ToString());
                x6_listSum += Double.Parse(x6_list[i].ToString());
                x7_listSum += Double.Parse(x7_list[i].ToString());
                x8_listSum += Double.Parse(x8_list[i].ToString());
                x9_listSum += Double.Parse(x9_list[i].ToString());              
            }
            double y_avg = y_listSum/y_list.Count, x1_avg = x1_listSum / x1_list.Count, x2_avg = x2_listSum / x2_list.Count, x3_avg = x3_listSum / x3_list.Count, x4_avg = x4_listSum / x4_list.Count, x5_avg = x5_listSum / x5_list.Count, x6_avg = x6_listSum / x6_list.Count, x7_avg = x7_listSum / x7_list.Count, x8_avg = x8_listSum / x8_list.Count, x9_avg = x9_listSum / x9_list.Count;
            double stdev_y = 0, stdev_x1 = 0, stdev_x2 = 0, stdev_x3 = 0, stdev_x4 = 0, stdev_x5 = 0, stdev_x6 = 0, stdev_x7 = 0, stdev_x8 = 0, stdev_x9 = 0;
            for (int i = 0; i < y_list.Count; i++)
            {
                stdev_y += Math.Pow((y_list[i] - y_avg), 2);
                stdev_x1 += Math.Pow((x1_list[i] - x1_avg), 2);
                stdev_x2 += Math.Pow((x2_list[i] - x2_avg), 2);               
                stdev_x3 += Math.Pow((x3_list[i] - x3_avg), 2);
                stdev_x4 += Math.Pow((x4_list[i] - x4_avg), 2);
                stdev_x5 += Math.Pow((x5_list[i] - x5_avg), 2);
                stdev_x6 += Math.Pow((x6_list[i] - x6_avg), 2);
                stdev_x7 += Math.Pow((x7_list[i] - x7_avg), 2);
                stdev_x8 += Math.Pow((x8_list[i] - x8_avg), 2);
                stdev_x9 += Math.Pow((x9_list[i] - x9_avg), 2);               
            }
            stdev_y = Math.Sqrt(stdev_y / (y_list.Count - 1));          
            stdev_x1 = Math.Sqrt(stdev_x1 / (x1_list.Count - 1));
            stdev_x2 = Math.Sqrt(stdev_x2 / (x2_list.Count - 1));
            stdev_x3 = Math.Sqrt(stdev_x3 / (x3_list.Count - 1));
            stdev_x4 = Math.Sqrt(stdev_x4 / (x4_list.Count - 1));
            stdev_x5 = Math.Sqrt(stdev_x5 / (x5_list.Count - 1));
            stdev_x6 = Math.Sqrt(stdev_x6 / (x6_list.Count - 1));
            stdev_x7 = Math.Sqrt(stdev_x7 / (x7_list.Count - 1));
            stdev_x8 = Math.Sqrt(stdev_x8 / (x8_list.Count - 1));
            stdev_x9 = Math.Sqrt(stdev_x9 / (x9_list.Count - 1));
            double percentage = 100;
            string[] Averages = new string[] {y_avg.ToString(), x1_avg.ToString(), x2_avg.ToString(), x3_avg.ToString(),
                                              x4_avg.ToString(), x5_avg.ToString(), x6_avg.ToString(),
                                              x7_avg.ToString(), x8_avg.ToString(), x9_avg.ToString()};
            string[] STDEVs = new string[] {stdev_y.ToString(), stdev_x1.ToString(), stdev_x2.ToString(), stdev_x3.ToString(),
                                            stdev_x4.ToString(), stdev_x5.ToString(), stdev_x6.ToString(),
                                            stdev_x7.ToString(), stdev_x8.ToString(), stdev_x9.ToString()};
            string[] PercentRandomError = new string[] {(stdev_y*percentage/y_avg).ToString(), (stdev_x1*percentage/x1_avg).ToString(), (stdev_x2*percentage/x2_avg).ToString(), (stdev_x3*percentage/x3_avg).ToString(),
                                                        (stdev_x4*percentage/x4_avg).ToString(), (stdev_x5*percentage/x5_avg).ToString(), (stdev_x6*percentage/x6_avg).ToString(),
                                                        (stdev_x7*percentage/x7_avg).ToString(), (stdev_x8*percentage/x8_avg).ToString(), (stdev_x9*percentage/x9_avg).ToString()};
            double[] STDEVs_double = new double[] { stdev_y, stdev_x1, stdev_x2, stdev_x3, stdev_x4, stdev_x5, stdev_x6, stdev_x7, stdev_x8, stdev_x9 };
            List<float>[] lists = new List<float>[] {y_list, x1_list, x2_list, x3_list, x4_list, x5_list, x6_list, x7_list, x8_list, x9_list};
            string[] StandardError = new string[lists.Length];
            for(int i = 0; i < StandardError.Length; i++)
            {
                StandardError[i] = (STDEVs_double[i] / Math.Sqrt(lists[i].Count)).ToString();
            }
            string[] Average_STDEV_csv = new string[Averages.Length + 1];
            CategoryName = new string[] { "Fantasy Points H2H", "FG%", "FT%", "3PTM", "PTS", "REB", "AST", "STL", "BLK", "TO" };
            Average_STDEV_csv[0] = "Category, Mean, Standard Deviation, Percent Random Error (%), Standard Error of the Mean, Median, Q1, Q3, IQR, Covariance with H2H Points, Correlation with H2H Points";
            float y_median = 0, x1_median = 0, x2_median = 0, x3_median = 0, x4_median = 0, x5_median = 0, x6_median = 0, x7_median = 0, x8_median = 0, x9_median = 0;
            float[] medians = new float[] { y_median, x1_median, x2_median, x3_median, x4_median, x5_median, x6_median, x7_median, x8_median, x9_median};
            float y_Q1 = 0, x1_Q1 = 0, x2_Q1 = 0, x3_Q1 = 0, x4_Q1 = 0, x5_Q1 = 0, x6_Q1 = 0, x7_Q1 = 0, x8_Q1 = 0, x9_Q1 = 0;
            float[] Q1s = new float[] { y_Q1, x1_Q1, x2_Q1, x3_Q1, x4_Q1, x5_Q1, x6_Q1, x7_Q1, x8_Q1, x9_Q1 };
            float y_Q3 = 0, x1_Q3 = 0, x2_Q3 = 0, x3_Q3 = 0, x4_Q3 = 0, x5_Q3 = 0, x6_Q3 = 0, x7_Q3 = 0, x8_Q3 = 0, x9_Q3 = 0;
            float[] Q3s = new float[] { y_Q3, x1_Q3, x2_Q3, x3_Q3, x4_Q3, x5_Q3, x6_Q3, x7_Q3, x8_Q3, x9_Q3 };
            float y_min = 0, x1_min = 0, x2_min = 0, x3_min = 0, x4_min = 0, x5_min = 0, x6_min = 0, x7_min = 0, x8_min = 0, x9_min = 0;        
            float[] category_min = new float[] { y_min, x1_min, x2_min, x3_min, x4_min, x5_min, x6_min, x7_min, x8_min, x9_min };
            float y_max = 0, x1_max = 0, x2_max = 0, x3_max = 0, x4_max = 0, x5_max = 0, x6_max = 0, x7_max = 0, x8_max = 0, x9_max = 0;
            float[] category_max = new float[] { y_max, x1_max, x2_max, x3_max, x4_max, x5_max, x6_max, x7_max, x8_max, x9_max};
            float y_IQR = 0, x1_IQR = 0, x2_IQR = 0, x3_IQR = 0, x4_IQR = 0, x5_IQR = 0, x6_IQR = 0, x7_IQR = 0, x8_IQR = 0, x9_IQR = 0;
            float[] IQR = new float[] { y_IQR, x1_IQR, x2_IQR, x3_IQR, x4_IQR, x5_IQR, x6_IQR, x7_IQR, x8_IQR, x9_IQR };
            int other_i = 0;
            float COV_Y_Y = 0, COV_Y_X1 = 0, COV_Y_X2 = 0, COV_Y_X3 = 0, COV_Y_X4 = 0, COV_Y_X5 = 0, COV_Y_X6 = 0, COV_Y_X7 = 0, COV_Y_X8 = 0, COV_Y_X9 = 0;
            float[] Covariances = new float[] { COV_Y_Y, COV_Y_X1, COV_Y_X2, COV_Y_X3, COV_Y_X4, COV_Y_X5, COV_Y_X6, COV_Y_X7, COV_Y_X8, COV_Y_X9 };
            float correl_Y_Y = 0, correl_Y_X1 = 0, correl_Y_X2 = 0, correl_Y_X3 = 0, correl_Y_X4 = 0, correl_Y_X5 = 0, correl_Y_X6 = 0, correl_Y_X7 = 0, correl_Y_X8 = 0, correl_Y_X9 = 0;
            float[] Correlations = new float[] {correl_Y_Y, correl_Y_X1, correl_Y_X2, correl_Y_X3, correl_Y_X4, correl_Y_X5, correl_Y_X6, correl_Y_X7, correl_Y_X8, correl_Y_X9 };
            List<string> y_list_outliers_check = new List<string>(); List<string> x1_list_outliers_check = new List<string>(); List<string> x2_list_outliers_check = new List<string>(); List<string> x3_list_outliers_check = new List<string>();
            List<string> x4_list_outliers_check = new List<string>(); List<string> x5_list_outliers_check = new List<string>(); List<string> x6_list_outliers_check = new List<string>();
            List<string> x7_list_outliers_check = new List<string>(); List<string> x8_list_outliers_check = new List<string>(); List<string> x9_list_outliers_check = new List<string>();
            List<string>[] ArrayOfLists_no_x0_Outliers = new List<string>[] { y_list_outliers_check, x1_list_outliers_check, x2_list_outliers_check, x3_list_outliers_check, x4_list_outliers_check, x5_list_outliers_check, x6_list_outliers_check, x7_list_outliers_check, x8_list_outliers_check, x9_list_outliers_check };
            foreach (List<float> i in ArrayOfLists_no_x0_Sorted)
            {
                i.Sort();
                int median_index = (i.Count + 1) / 2;
                float one_quarter = float.Parse(0.25.ToString());
                float three_quarters = float.Parse(0.75.ToString());
                int Q1_index = median_index / 2;
                int Q3_index = 3 * median_index / 2;
                category_min[other_i] = i[0];
                category_max[other_i] = i[i.Count - 1];
                if ((i.Count % 4) == 0 || (i.Count % 4 == 2))  
                {
                    medians[other_i] = (i[median_index] + i[median_index - 1]) / 2;
                    if (i.Count % 4 == 0)
                    {
                        Q1s[other_i] = i[Q1_index - 1] * three_quarters + i[Q1_index] * one_quarter;
                        Q3s[other_i] = i[Q3_index - 1] * one_quarter + i[Q3_index] * three_quarters;
                    }
                    else
                    {
                        Q1s[other_i] = i[Q1_index - 1] * one_quarter + i[Q1_index] * three_quarters;
                        Q3s[other_i] = i[Q3_index - 1] * three_quarters + i[Q3_index] * one_quarter;
                    }
                }
                else if ((i.Count % 4) == 1 || (i.Count % 4 == 3)) 
                {
                    medians[other_i] = i[median_index - 1];
                    if (i.Count % 4 == 1)
                    {
                        Q1s[other_i] = i[Q1_index - 1] * three_quarters + i[Q1_index] * one_quarter;
                        Q3s[other_i] = i[Q3_index - 1] * one_quarter + i[Q3_index] * three_quarters;
                    }
                    else
                    {
                        Q1s[other_i] = i[Q1_index - 1] * one_quarter + i[Q1_index] * three_quarters;
                        Q3s[other_i] = i[Q3_index - 1] * three_quarters + i[Q3_index] * one_quarter;
                    }
                }
                IQR[other_i] = Q3s[other_i] - Q1s[other_i];
                other_i++;
            }
            int Covariances_index = 0;
            foreach(List<float> a in ArrayOfLists_no_X0_UNSORTED)
            {
                for(int Covariances_i = 0; Covariances_i < y_list.Count; Covariances_i++)
                {
                    Covariances[Covariances_index] += (a[Covariances_i] - float.Parse(Averages[Covariances_index])) * (y_list_unsorted[Covariances_i] - float.Parse(y_avg.ToString())) / (y_list.Count - 1);
                }
                Correlations[Covariances_index] = Covariances[Covariances_index] / (float.Parse(stdev_y.ToString()) * float.Parse(STDEVs[Covariances_index]));
                Covariances_index++;
            }
            for (int i = 1; i < CategoryName.Length + 1; i++)
            {
                Average_STDEV_csv[i] = CategoryName[i - 1].ToString() + "," + Averages[i - 1].ToString() + "," + STDEVs[i - 1].ToString() + "," +
                                       PercentRandomError[i - 1].ToString() + "," + StandardError[i - 1] + "," + medians[i - 1].ToString() + "," +
                                       Q1s[i - 1].ToString() + "," + Q3s[i - 1].ToString() + "," + IQR[i - 1].ToString() + "," + Covariances[i - 1].ToString() + "," + Correlations[i - 1].ToString() + ",";
            }
            string DataFileName_AveragesAndSTDEVS = InitialDirectory + end_datafilename.Substring(0, end_datafilename.Length - 4) + " Category Means and STDEVs.csv";
            File.WriteAllLines(DataFileName_AveragesAndSTDEVS, Average_STDEV_csv);
            int another_i = 0;
            foreach (List<float> i in ArrayOfLists_no_x0_Sorted)
            {
                for(int j = 0; j < i.Count; j++)
                {
                    if(i[j] > (1.5*IQR[another_i] + Q3s[another_i]) || i[j] < (Q1s[another_i] - 1.5 * IQR[another_i]))
                    {
                        ArrayOfLists_no_x0_Outliers[another_i].Add("Yes");
                    }
                    else
                    {
                        ArrayOfLists_no_x0_Outliers[another_i].Add("No");
                    }
                }
                another_i++;
            }           
            string DataFileName_Outliers = InitialDirectory + end_datafilename.Substring(0, end_datafilename.Length - 4) + " Outliers.csv";
            string[] DataFileName_Outliers_Content = new string[y_list.Count];
            DataFileName_Outliers_Content[0] = "H2H Points, Outlier?, FG%, Outlier or not?, FT%, Outlier?, 3PTM, Outlier?, PTS, Outlier?, REB, Outlier?, AST, Outlier?, STL, Outlier?, BLK, Outlier?, TO, Outlier? ";
            for (int i = 1; i < DataFileName_Outliers_Content.Length; i++)
            {
                DataFileName_Outliers_Content[i] = y_list[i - 1] + "," + y_list_outliers_check[i - 1] + "," + x1_list[i - 1] + "," + x1_list_outliers_check[i - 1] + "," + x2_list[i - 1] + "," + x2_list_outliers_check[i - 1] + "," + x3_list[i-1] + "," + x3_list_outliers_check[i-1] + "," + x4_list[i - 1] + "," + x4_list_outliers_check[i - 1] + "," + x5_list[i - 1] + "," + x5_list_outliers_check[i - 1] + "," + x6_list[i - 1] + "," + x6_list_outliers_check[i - 1] + "," + x7_list[i - 1] + "," + x7_list_outliers_check[i - 1] + "," + x8_list[i - 1] + "," + x8_list_outliers_check[i - 1] + "," + x9_list[i - 1] + "," + x9_list_outliers_check[i - 1]  + ",";
            }
            File.WriteAllLines(DataFileName_Outliers, DataFileName_Outliers_Content);
            float[,] X_TransposeMatrix = new float[Regressors.Count, NumDataPoints];  //for loop below transposes the X Matrix for the calculations to be done later on.
            for (int i = 0; i < NumDataPoints; i++)
            {
                for (int j = 0; j < Regressors.Count; j++)
                {
                    X_TransposeMatrix[j, i] = X_Matrix[i, j];
                }
            }
            float[,] X_Transpose_X_Matrix = new float[Regressors.Count, Regressors.Count]; 
            MatrixMultiplication2_2DMatrix(X_TransposeMatrix, X_Matrix);
            MatrixMultiplication1_2DMatrix(X_TransposeMatrix, Y_Matrix);
            X_Transpose_Y_Matrix = D;
            Thread.Sleep(50);
            write_X_Transpose_X_Matrix(C);
            DataFileName_X_Transpose_X_Matrix_Inverse = InitialDirectory + end_datafilename.Substring(0, end_datafilename.Length - 4) + " X_Transpose_X_Matrix Inverse.csv";
            Write_inverted_X_Transpose_X_Matrix_Python_and_GnuplotGraphs(DataFileName_X_Transpose_X_Matrix, FullDataFileName, GnuplotTemplateDirectory);
            Thread.Sleep(2000); //done to write the files, time is in miliseconds
            string[] X_Transpose_X_Matrix_Inverse_Content = File.ReadAllLines(DataFileName_X_Transpose_X_Matrix_Inverse);
            long datapoints = X_Transpose_X_Matrix_Inverse_Content.Length;
            string[] splitDataInverse;
            string col_1 = "col1", col_2 = "col2", col_3 = "col3", col_4 = "col4", col_5 = "col5", col_6 = "col6", col_7 = "col7", col_8 = "col8", col_9 = "col9", col_10 = "col10";
            List<string> InverseValues = new List<string>();
            string[] InverseValues_Array = new string[] { col_1, col_2, col_3, col_4, col_5, col_6, col_7, col_8, col_9, col_10 };
            for (int i = 0; i < InverseValues_Array.Length; i++)
            {
                InverseValues.Add(InverseValues_Array[i]);
            }
            int col1_index = InverseValues.IndexOf(col_1), col2_index = InverseValues.IndexOf(col_2), col3_index = InverseValues.IndexOf(col_3), col4_index = InverseValues.IndexOf(col_4), col5_index = InverseValues.IndexOf(col_5), col6_index = InverseValues.IndexOf(col_6), col7_index = InverseValues.IndexOf(col_7), col8_index = InverseValues.IndexOf(col_8), col9_index = InverseValues.IndexOf(col_9), col10_index = InverseValues.IndexOf(col_10);
            List<float> col1List = new List<float>(); List<float> col2List = new List<float>(); List<float> col3List = new List<float>();
            List<float> col4List = new List<float>(); List<float> col5List = new List<float>(); List<float> col6List = new List<float>();
            List<float> col7List = new List<float>(); List<float> col8List = new List<float>(); List<float> col9List = new List<float>(); List<float> col10List = new List<float>();
            float[,] X_Transpose_X_Inverse_Matrix = new float[datapoints, datapoints];
            List<float>[] columns = new List<float>[] {col1List, col2List, col3List, col4List, col5List, col6List, col7List, col8List, col9List, col10List};
            int[] columns_index = new int[] { col1_index, col2_index, col3_index, col4_index, col5_index, col6_index, col7_index, col8_index, col9_index, col10_index };
            int index_columns = 0;
            foreach(List<float> a in columns)
            {
                for(int i = 0; i < datapoints; i++)
                {
                    splitDataInverse = X_Transpose_X_Matrix_Inverse_Content[i].Split(',');
                    a.Add(float.Parse(splitDataInverse[columns_index[index_columns]]));
                    X_Transpose_X_Inverse_Matrix[i, index_columns] = a[i];
                }
                index_columns++;
            }
            MatrixMultiplication1_2DMatrixSecondTime(X_Transpose_X_Inverse_Matrix, D);
            write_Beta_Matrix(E);
            Beta_Matrix = E;
            writeANOVA(Y_Matrix, X_Transpose_X_Inverse_Matrix, Regressor_Name, E, CategoryName);
        }
        public static void write_X_Transpose_X_Matrix(float[,] X_Tranpose_X_Matrix)
        {
            string end_datafilename_X_Transpose = end_datafilename.Substring(0, end_datafilename.Length - 4) + " X_Transpose_X_Matrix.csv";
            DataFileName_X_Transpose_X_Matrix = InitialDirectory + end_datafilename_X_Transpose;
            string[] X_Transpose_FileContent = new string[Regressors.Count];
            for (int i = 0; i < X_Transpose_FileContent.Length; i++)
            {
                for (int j = 0; j < X_Transpose_FileContent.Length; j++)
                {
                    if (j!= X_Transpose_FileContent.Length - 1)
                    {
                        X_Transpose_FileContent[i] += X_Tranpose_X_Matrix[i, j] + ",";
                    }
                    else
                    {
                        X_Transpose_FileContent[i] += X_Tranpose_X_Matrix[i, j];
                    }
                }
            }
            File.WriteAllLines(DataFileName_X_Transpose_X_Matrix, X_Transpose_FileContent);
        }
        public static void Write_inverted_X_Transpose_X_Matrix_Python_and_GnuplotGraphs(string DataFileName_X_Transpose_X_Matrix, string FullDataFileName, string GnuplotTemplateDirectory)
        {
            //running python for the matrix inversion
            string DataDirectory = "C:\\Users\\Andres\\PycharmProjects\\dankmemes\\venv\\Scripts\\"; 
            string pythonFileNameTemplate = "MatrixInversion.py";
            string pythonFileNameTemplateContents = File.ReadAllText(DataDirectory + pythonFileNameTemplate);
            DataFileName_X_Transpose_X_Matrix = DataFileName_X_Transpose_X_Matrix.Replace('\\', '/');
            DataFileName_X_Transpose_X_Matrix_Inverse = DataFileName_X_Transpose_X_Matrix_Inverse.Replace('\\', '/');
            if (pythonFileNameTemplateContents.Contains("TransposeMatrixHere"))
            {
                pythonFileNameTemplateContents = pythonFileNameTemplateContents.Replace("TransposeMatrixHere", DataFileName_X_Transpose_X_Matrix);
            }
            if (pythonFileNameTemplateContents.Contains("InverseMatrixHere"))
            {
                pythonFileNameTemplateContents = pythonFileNameTemplateContents.Replace("InverseMatrixHere", DataFileName_X_Transpose_X_Matrix_Inverse);
            }
            string pythonFileName = DataDirectory + "MatrixInversionModified.py";
            File.WriteAllText(pythonFileName, pythonFileNameTemplateContents);
            ProcessStartInfo startinfo = new ProcessStartInfo("python.exe");
            startinfo.Arguments = pythonFileName;
            startinfo.WorkingDirectory = DataDirectory;
            startinfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startinfo);
            //running gnuplot for the graphs  --> remember that Gnuplot does not like Spaces in the raw data file csv!
            string GnuplotTemplate = GnuplotTemplateDirectory + "MultipleLinearRegressionGnuplotTemplate.gp";
            string GnuplotTemplateContents = File.ReadAllText(GnuplotTemplate);
            if (GnuplotTemplateContents.Contains("BaseNameHere"))
            {
                GnuplotTemplateContents = GnuplotTemplateContents.Replace("BaseNameHere", end_datafilename.Substring(0, end_datafilename.Length - 4));
            }
            DataDirectory = InitialDirectory;
            string GnuplotTemplateFileNameModified = InitialDirectory + end_datafilename.Substring(0, end_datafilename.Length - 4) + "-Gnuplot-Template-Modified.gp";
            File.WriteAllText(GnuplotTemplateFileNameModified, GnuplotTemplateContents);
            ProcessStartInfo startinfo1 = new ProcessStartInfo("wgnuplot.exe");
            startinfo1.Arguments = GnuplotTemplateFileNameModified;
            startinfo1.WorkingDirectory = DataDirectory;
            startinfo1.WindowStyle = ProcessWindowStyle.Hidden;
            startinfo1.UseShellExecute = false;
            Process.Start(startinfo1);
        }
        public static void write_Beta_Matrix(float[] Beta_Matrix)
        {
            string end_datafilename_Beta_Matrix = end_datafilename.Substring(0, end_datafilename.Length - 4) + " Beta_Matrix.csv";
            string DataFileName_Beta_Matrix = InitialDirectory + end_datafilename_Beta_Matrix;
            string[] Beta_Matrix_FileContent = new string[Regressors.Count + 1];
            Regressor_Name = new string[] { "beta_0", "beta_1", "beta_2", "beta_3", "beta_4", "beta_5", "beta_6", "beta_7", "beta_8", "beta_9" }; 
            Beta_Matrix_FileContent[0] = "Regressor Name (Beta Name), Regressor Value (Beta value),";
            for (int i = 1; i < Beta_Matrix_FileContent.Length; i++)
            {
                Beta_Matrix_FileContent[i] = Regressor_Name[i - 1].ToString() + "," + Beta_Matrix[i - 1].ToString() + ",";
            }
            File.WriteAllLines(DataFileName_Beta_Matrix, Beta_Matrix_FileContent);
        }
        public static void writeANOVA(float[] Y_Matrix, float[,] X_Transpose_X_Inverse_Matrix , string[] Regressor_Name, float[] E, string[] CategoryName)
        {
            float[,] Y_Transpose_Matrix = new float[1, Y_Matrix.Length];            //Calculating SST --> which is Y_Transpose_Y_Matrix (one element) - (Sum of y values) ^ 2 over n
            for (int i = 0; i < Y_Matrix.Length; i++)
            {
                Y_Transpose_Matrix[0, i] = Y_Matrix[i];
            }
            float Y_Transpose_Y_Matrix = 0;
            for (int i = 0; i < Y_Transpose_Matrix.GetLength(1); i++)
            {
                Y_Transpose_Y_Matrix += Y_Transpose_Matrix[0, i] * Y_Matrix[i];
            }
            double Y_Transpose_Y_Matrix_double = double.Parse(Y_Transpose_Y_Matrix.ToString());
            float y_list_sum = 0;
            for (int i = 0; i < y_list.Count; i++)
            {
                y_list_sum += y_list[i];
            }
            double y_list_sum_double = double.Parse(y_list_sum.ToString());
            SST = Y_Transpose_Y_Matrix - (Math.Pow(y_list_sum_double, 2) / y_list.Count);
            float[,] Beta_Transpose_Matrix = new float[1, Beta_Matrix.Length];      //Calculating SSR --> which is Beta_Tranpose_Matrix * X_Transpose_Y_Matrix - y_list_sum_double;
            for (int i = 0; i < Beta_Transpose_Matrix.GetLength(1); i++)
            {
                Beta_Transpose_Matrix[0, i] = Beta_Matrix[i];
            }
            float Beta_Transpose_X_Transpose_Y_Matrix = 0;
            for (int i = 0; i < Beta_Transpose_Matrix.GetLength(1); i++)
            {
                Beta_Transpose_X_Transpose_Y_Matrix += Beta_Transpose_Matrix[0, i] * X_Transpose_Y_Matrix[i];
            }
            double Beta_Transpose_X_Transpose_Y_Matrix_double = double.Parse(Beta_Transpose_X_Transpose_Y_Matrix.ToString());
            SSR = Beta_Transpose_X_Transpose_Y_Matrix_double - (Math.Pow(y_list_sum_double, 2) / y_list.Count);
            SSE = SST - SSR;
            DF_Regression = Regressors.Count - 1;
            DF_Error = y_list.Count - (DF_Regression + 1);
            DF_Total = DF_Regression + DF_Error;
            Mean_Square_Regression = SSR / DF_Regression;
            Mean_Square_Error = SSE / DF_Error;
            SigmaSquared = Mean_Square_Error;
            F_Statistic = Mean_Square_Regression / Mean_Square_Error; //to get P_value, you need the tables            
            RSquared = SSR / SST; //determines how much the MLR model accounts for about x% variability in y
            RSquaredAdjusted = 1 - ((SSE / DF_Error) / (SST / DF_Total)); //adjusted R^2 penalizes the analyst for adding the terms to the model, prevents overfitting regressors        
            string end_datafilenameANOVA_Matrix = end_datafilename.Substring(0, end_datafilename.Length - 4) + " ANOVA Table and 95% Double Sided Confidence Intervals.csv";
            string DataFileName_ANOVA_Matrix = InitialDirectory + end_datafilenameANOVA_Matrix;
            string[] ANOVA_Matrix_FileContent = new string[6 + Regressors.Count];
            ANOVA_Matrix_FileContent[0] = "Source of Variation, Sum of Squares, Degrees of Freedom, Mean Square, F_0, R Squared, R Squared Adjusted";
            ANOVA_Matrix_FileContent[1] = "Regression" + "," + SSR + "," + DF_Regression + "," + Mean_Square_Regression + "," + F_Statistic + "," + RSquared + "," + RSquaredAdjusted;
            ANOVA_Matrix_FileContent[2] = "Error or Residual" + "," + SSE + "," + DF_Error + "," + Mean_Square_Error;
            ANOVA_Matrix_FileContent[3] = "Total" + "," + SST + "," + DF_Total;  
            ANOVA_Matrix_FileContent[5] = "Regressor, Fantasy Statistic, Beta_Value, Lower Double Sided Confidence Interval Bound, Upper Double Sided Confidence Interval Bound, Marginal T-Tests T-Value, T-Value, Reject Null Hypothesis?";
            double[] LowerConfidenceIntervalDoubleSided = new double[Regressors.Count];
            double[] UpperConfidenceIntervalDoubleSided = new double[Regressors.Count];
            double[] marginal_T_Tests = new double[Regressors.Count];
            string[] Reject_or_Fail_Null = new string[Regressors.Count];
            double t_value_alphaOverTwo_NminusP = 2.228;    /* 2.074 for the example in Lena's notes (3 regressors, 25 observations)*/ 
            for (int i = 0; i < Regressors.Count; i++)
            {
                LowerConfidenceIntervalDoubleSided[i] = E[i] - t_value_alphaOverTwo_NminusP * Math.Sqrt(SigmaSquared * X_Transpose_X_Inverse_Matrix[i, i]);
                UpperConfidenceIntervalDoubleSided[i] = E[i] + t_value_alphaOverTwo_NminusP * Math.Sqrt(SigmaSquared * X_Transpose_X_Inverse_Matrix[i, i]);
                marginal_T_Tests[i] = E[i] / Math.Sqrt(SigmaSquared * X_Transpose_X_Inverse_Matrix[i, i]);
                if(Math.Abs(marginal_T_Tests[i]) < t_value_alphaOverTwo_NminusP)
                {
                    Reject_or_Fail_Null[i] = "Fail to reject null hypothesis - variable does not contribute significantly to the model";
                }
                else if (Math.Abs(marginal_T_Tests[i]) > t_value_alphaOverTwo_NminusP || marginal_T_Tests[i] < -1*t_value_alphaOverTwo_NminusP)
                {
                    Reject_or_Fail_Null[i] = "Reject null hypothesis - variable contributes significantly to the model";
                }
            }
            ANOVA_Matrix_FileContent[6] = Regressor_Name[0] + "," + "Model Intercept," + E[0] + "," + LowerConfidenceIntervalDoubleSided[0] + ","+ UpperConfidenceIntervalDoubleSided[0] + "," + marginal_T_Tests[0] + "," + t_value_alphaOverTwo_NminusP + "," + Reject_or_Fail_Null[0] + ",";
            for (int i = 7; i < Regressors.Count + 6; i++)
            {
                ANOVA_Matrix_FileContent[i] = Regressor_Name[i - 6] + "," + CategoryName[i - 6] + "," + E[i - 6] + "," + LowerConfidenceIntervalDoubleSided[i - 6] + "," + UpperConfidenceIntervalDoubleSided[i - 6] + "," + marginal_T_Tests[i - 6] + "," + t_value_alphaOverTwo_NminusP + "," + Reject_or_Fail_Null[i - 6] + ",";
            }
            File.WriteAllLines(DataFileName_ANOVA_Matrix, ANOVA_Matrix_FileContent);
        }
        public static float[,] MatrixMultiplication2_2DMatrix(float[,] A, float[,] B)
        {
            for (int i = 0; i < A.GetLength(0); i++)   //for loop multiplies X_TranposeMatrix with X_Matrix
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return C;
        }
        public static float[] MatrixMultiplication1_2DMatrix(float[,] A, float[] B)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        D[i] += A[i, k] * B[k];
                    }
                }
            }
            return D;
        }
        public static float[] MatrixMultiplication1_2DMatrixSecondTime(float[,] A, float[] B)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        E[i] += A[i, k] * B[k];
                    }
                }
            }
            return E;
        }
    }
}