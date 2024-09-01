using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace TubeSaver
{
    internal class YouTubeService
    {
        private Label labelStatusUsuario;

        public YouTubeService(Label label)
        {
            labelStatusUsuario = label;
        }
        public async Task DownloadAndMergeVideoAsync(string url, IStreamInfo videoStream, string destinationPath, Label labelStatus)
        {
            var youtube = new YoutubeClient();
            var videoId = YoutubeExplode.Videos.VideoId.Parse(url);
            UpdateStatusLabel("Iniciando mágica de dev...");
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
            UpdateStatusLabel("Integrando serviços...");
            var audioStream = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            if (videoStream == null || audioStream == null)
            {
                throw new Exception("Não foi possível encontrar os streams necessários.");
            }

            string tempVideoPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_video.mp4");
            string tempAudioPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_audio.mp4");
            string tempOutputPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_final.wmv");

            try
            {
                UpdateStatusLabel("Iniciando download do vídeo...");
                await DownloadStreamAsync(youtube, videoStream, tempVideoPath);
                UpdateStatusLabel("Iniciando download do áudio...");
                await DownloadStreamAsync(youtube, audioStream, tempAudioPath);
                UpdateStatusLabel("Iniciando mágica!");
                MargeVideoAndAudioWithFFmpeg(tempVideoPath, tempAudioPath, tempOutputPath);
                UpdateStatusLabel("Mágica de dev concluída!");

                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }
                File.Move(tempOutputPath, destinationPath);
                UpdateStatusLabel("Processo concluído.");

                Console.WriteLine($"Download e mesclagem concluídos: {destinationPath}");

            }
            finally
            {
                DeleteTemporaryFile(tempVideoPath);
                DeleteTemporaryFile(tempAudioPath);
                DeleteTemporaryFile(tempOutputPath);
            }


        }



        private static async Task DownloadStreamAsync(YoutubeClient youtube, IStreamInfo streamInfo, string filePath)
        {
            long totalBytes = streamInfo.Size.Bytes;
            long downloadedBytes = 0;

            using (var stream = await youtube.Videos.Streams.GetAsync(streamInfo))
            using (var fileStream = File.Create(filePath))
            {
                byte[] buffer = new byte[8192];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, bytesRead);
                    downloadedBytes += bytesRead;
                }
            }
        }


        private static void MargeVideoAndAudioWithFFmpeg(string videoPath, string audioPath, string outputPath)
        {
            string ffmpegPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg", "bin", "ffmpeg.exe");

            if (!File.Exists(ffmpegPath))
            {
                throw new FileNotFoundException("FFmpeg não encontrado no caminho especificado.");
            }

           
            outputPath = Path.ChangeExtension(outputPath, ".wmv");


            //string arguments = $"-i \"{videoPath}\" -i \"{audioPath}\" -c:v wmv2 -c:a wmav2 -shortest \"{outputPath}\"";
            string arguments = $"-i \"{videoPath}\" -i \"{audioPath}\" -c:v wmv2 -b:v 3000k -c:a wmav2 -b:a 192k -shortest \"{outputPath}\"";

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = ffmpegPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Console.WriteLine($"FFmpeg stderr: {e.Data}");
                }
            };

            try
            {
                process.Start();
                process.BeginErrorReadLine();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"Erro na mesclagem com FFmpeg. Código de saída: {process.ExitCode}");
                }
                else
                {
                    Console.WriteLine("Mesclagem concluída com sucesso!");
                }
            }
            finally
            {
                process.Close();
            }
        }

        private static void DeleteTemporaryFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao tentar excluir oa rquivo temporário {filePath} : {ex.Message}");
                }
            }
        }

        private void UpdateStatusLabel(string message)
        {
            if (labelStatusUsuario.InvokeRequired)
            {
                labelStatusUsuario.Invoke((MethodInvoker)(() => labelStatusUsuario.Text = message));
            }
            else
            {
                labelStatusUsuario.Text = message;
            }
        }
    }
}