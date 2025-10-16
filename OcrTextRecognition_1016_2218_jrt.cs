// 代码生成时间: 2025-10-16 22:18:32
using System;
using System.Threading.Tasks;
using Tesseract;

namespace XamarinOcrApp
{
    // OcrTextRecognition类负责实现OCR文字识别功能
    public class OcrTextRecognition
    {
        private readonly TesseractEngine _engine;

        // 构造函数初始化Tesseract引擎
        public OcrTextRecognition()
        {
            var dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _engine = new TesseractEngine(dataPath, "eng", EngineMode.Default);
        }

        // 执行OCR识别的方法
        public async Task<string> RecognizeTextFromImageAsync(string imagePath)
        {
            try
            {
                // 确保图片路径有效
                if (string.IsNullOrEmpty(imagePath))
                {
                    throw new ArgumentException("Image path cannot be null or empty.");
                }

                using var img = Pix.LoadFromFile(imagePath);
                using var page = _engine.Process(img);

                // 获取识别的文本结果
                string recognizedText = page.GetText();

                // 清理资源
                img.Dispose();
                page.Dispose();

                return recognizedText;
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"Error occurred during OCR: {ex.Message}");
                return null;
            }
        }
    }
}

// 注意：此代码假设您已安装Tesseract库，并正确配置了Tesseract的路径。
// 请确保在项目中添加对Tesseract的引用，并下载相应的语言包。