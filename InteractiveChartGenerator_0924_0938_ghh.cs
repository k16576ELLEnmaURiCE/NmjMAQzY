// 代码生成时间: 2025-09-24 09:38:07
using System;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

// 交互式图表生成器
# TODO: 优化性能
public class InteractiveChartGenerator : ContentPage
# 改进用户体验
{
    private SKCanvasView canvasView;
# 改进用户体验
    private SKPaint textPaint;
    private SKPaint linePaint;
    private float[] points;

    public InteractiveChartGenerator()
    {
        // 初始化画布
        canvasView = new SKCanvasView
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand
        };

        // 设置画笔
        textPaint = new SKPaint
# 改进用户体验
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black,
            TextSize = 30
        };

        linePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 5,
# NOTE: 重要实现细节
            Color = SKColors.Blue
        };

        // 添加画布到页面
        Content = canvasView;

        // 注册触摸事件
        canvasView.Touch += OnTouch;
    }

    private void OnTouch(object sender, TouchEventArgs e)
# 扩展功能模块
    {
        switch (e.ActionType)
        {
            case TouchActionType.Pressed:
                // 处理触摸按下事件
                HandleTouchDown(e.Location);
                break;
            case TouchActionType.Moved:
                // 处理触摸移动事件
                HandleTouchMove(e.Location);
                break;
            case TouchActionType.Released:
                // 处理触摸释放事件
                HandleTouchUp();
                break;
        }
    }

    private void HandleTouchDown(Point location)
    {
        // 添加新的点到点数组
        points = AddPointToArray(points, location.X, location.Y);
        // 触发画布重绘
        canvasView.InvalidateSurface();
    }
# FIXME: 处理边界情况

    private void HandleTouchMove(Point location)
# TODO: 优化性能
    {
        // 更新点数组中的最后一个点
        UpdateLastPointInArray(points, location.X, location.Y);
# TODO: 优化性能
        // 触发画布重绘
        canvasView.InvalidateSurface();
    }

    private void HandleTouchUp()
    {
        // 完成绘制
    }

    private float[] AddPointToArray(float[] array, float x, float y)
# 优化算法效率
    {
# NOTE: 重要实现细节
        if (array == null)
        {
            return new[] { x, y };
        }
        else
# 扩展功能模块
        {
            var newPoints = new float[array.Length + 2];
            Array.Copy(array, newPoints, array.Length);
            newPoints[array.Length] = x;
            newPoints[array.Length + 1] = y;
            return newPoints;
        }
    }

    private void UpdateLastPointInArray(float[] array, float x, float y)
    {
        if (array == null || array.Length < 2)
        {
            return;
        }
        array[array.Length - 2] = x;
        array[array.Length - 1] = y;
# 改进用户体验
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // 清理资源
        canvasView?.Dispose();
    }
# NOTE: 重要实现细节

    // 重写OnPaintSurface方法进行绘制
    private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        SKSurface surface = e.Surface;
        SKCanvas canvas = surface.Canvas;
        canvas.Clear();

        if (points != null && points.Length > 1)
# 增强安全性
        {
            for (int i = 0; i < points.Length - 2; i += 2)
            {
                float x1 = points[i];
                float y1 = points[i + 1];
# 添加错误处理
                float x2 = points[i + 2];
                float y2 = points[i + 3];

                // 绘制线条
                canvas.DrawLine(x1, y1, x2, y2, linePaint);
            }
        }
    }
}
