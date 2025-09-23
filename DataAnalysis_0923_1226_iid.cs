// 代码生成时间: 2025-09-23 12:26:19
// DataAnalysis.cs
// 这是一个使用C#和Xamarin框架实现的统计数据分析器。

using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinDataAnalysis
{
    /// <summary>
    /// 统计数据分析器
    /// </summary>
    public class DataAnalysis
    {
        private List<double> data;

        /// <summary>
        /// 构造函数，初始化数据集合
        /// </summary>
        /// <param name="dataList">数据列表</param>
        public DataAnalysis(List<double> dataList)
        {
            if (dataList == null || dataList.Count == 0)
            {
                throw new ArgumentException("Data list cannot be null or empty.");
            }
            this.data = dataList;
        }

        /// <summary>
        /// 计算平均值
        /// </summary>
        /// <returns>平均值</returns>
        public double CalculateMean()
        {
            return data.Average();
        }

        /// <summary>
        /// 计算中位数
        /// </summary>
        /// <returns>中位数</returns>
        public double CalculateMedian()
        {
            var sortedData = data.OrderBy(x => x).ToList();
            var mid = sortedData.Count / 2;
            if (sortedData.Count % 2 == 0)
            {
                return (sortedData[mid - 1] + sortedData[mid]) / 2.0;
            }
            else
            {
                return sortedData[mid];
            }
        }

        /// <summary>
        /// 计算最大值
        /// </summary>
        /// <returns>最大值</returns>
        public double CalculateMax()
        {
            return data.Max();
        }

        /// <summary>
        /// 计算最小值
        /// </summary>
        /// <returns>最小值</returns>
        public double CalculateMin()
        {
            return data.Min();
        }

        /// <summary>
        /// 计算标准差
        /// </summary>
        /// <returns>标准差</returns>
        public double CalculateStandardDeviation()
        {
            var mean = CalculateMean();
            var variance = data.Average(x => Math.Pow(x - mean, 2));
            return Math.Sqrt(variance);
        }
    }
}
