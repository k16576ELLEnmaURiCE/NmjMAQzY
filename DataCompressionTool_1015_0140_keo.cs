// 代码生成时间: 2025-10-15 01:40:19
// DataCompressionTool.cs
// 一个用于数据压缩和解压的工具类。

using System;
using System.IO;
using System.IO.Compression;

namespace DataCompressionToolNamespace
{
    public class DataCompressionTool
    {
        // 压缩文件
        public static byte[] CompressFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("文件未找到", filePath);
                }

                byte[] fileBytes = File.ReadAllBytes(filePath);
                using (var compressedStream = new MemoryStream())
                {
                    using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                    {
                        gzipStream.Write(fileBytes, 0, fileBytes.Length);
                    }
                    return compressedStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"压缩过程中发生错误：{ex.Message}");
                return null;
            }
        }

        // 解压文件
        public static byte[] DecompressFile(byte[] compressedData)
        {
            try
            {
                using (var compressedStream = new MemoryStream(compressedData))
                {
                    using (var decompressedStream = new MemoryStream())
                    {
                        using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                        {
                            gzipStream.CopyTo(decompressedStream);
                        }
                        return decompressedStream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"解压过程中发生错误：{ex.Message}");
                return null;
            }
        }
    }
}
