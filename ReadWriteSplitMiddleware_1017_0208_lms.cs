// 代码生成时间: 2025-10-17 02:08:22
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

// 读写分离中间件实现类
public class ReadWriteSplitMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ReadWriteSplitMiddleware> _logger;
    private readonly string _masterConnectionString;
    private readonly string _slaveConnectionString;
    private readonly IConnectionManager _connectionManager;

    // 构造函数
    public ReadWriteSplitMiddleware(RequestDelegate next, ILogger<ReadWriteSplitMiddleware> logger, string masterConnectionString, string slaveConnectionString, IConnectionManager connectionManager)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _masterConnectionString = masterConnectionString ?? throw new ArgumentNullException(nameof(masterConnectionString));
        _slaveConnectionString = slaveConnectionString ?? throw new ArgumentNullException(nameof(slaveConnectionString));
        _connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
    }

    // 处理请求的异步方法
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // 根据请求方法确定使用主库还是从库
            string connectionString = context.Request.Method == HttpMethods.Get || context.Request.Method == HttpMethods.Head || context.Request.Method == HttpMethods.Options ? _slaveConnectionString : _masterConnectionString;

            // 使用相应的数据库连接字符串
            _connectionManager.SetConnectionString(connectionString);

            // 调用管道中的下一个中间件组件
            await _next(context);
        }
        catch (Exception ex)
        {
            // 错误处理
            _logger.LogError(ex, "An error occurred while processing the request in ReadWriteSplitMiddleware.");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}

// 数据库连接管理接口
public interface IConnectionManager
{
    void SetConnectionString(string connectionString);
}

// 示例数据库连接管理器实现
public class DefaultConnectionManager : IConnectionManager
{
    private string _connectionString;

    // 设置数据库连接字符串
    public void SetConnectionString(string connectionString)
    {
        _connectionString = connectionString;
    }

    // 获取数据库连接字符串
    public string GetConnectionString()
    {
        return _connectionString;
    }
}