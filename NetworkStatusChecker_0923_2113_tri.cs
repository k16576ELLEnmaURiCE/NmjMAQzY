// 代码生成时间: 2025-09-23 21:13:44
using System;
using Xamarin.Essentials;

namespace XamarinNetworkCheck
{
    // 网络状态检查器类
    public class NetworkStatusChecker
    {
        /// <summary>
        /// 检查网络连接状态
        /// </summary>
        /// <returns>网络连接状态</returns>
        public async Task<Connectivity> CheckNetworkStatusAsync()
        {
            try
            {
                // 获取当前的网络连接状态
                var connectivity = await Connectivity.CheckConnectivityAsync();
                return connectivity;
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"Error checking network status: {ex.Message}");
                return Connectivity.None; // 网络连接失败时返回None
            }
        }

        /// <summary>
        /// 检查是否有互联网连接
        /// </summary>
        /// <returns>布尔值，表示是否连接到互联网</returns>
        public async Task<bool> IsConnectedToInternetAsync()
        {
            try
            {
                // 获取当前网络连接状态
                var networkAccess = await Connectivity.CheckAccessAsync();
                return networkAccess == NetworkAccess.Internet;
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"Error checking internet connection: {ex.Message}");
                return false; // 如果发生错误，则假定无互联网连接
            }
        }
    }
}
