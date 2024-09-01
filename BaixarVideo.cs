using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode.Videos.Streams;

namespace TubeSaver
{
    internal class ProcessarVideo
    {
        private Label labelStatus;

        public ProcessarVideo(Label statusLabel)
        {
            labelStatus = statusLabel;
        }

        public async Task BaixarVideoAsync(string url, IStreamInfo videoStream, string filePath)
        {
            try
            {
                var youtubeService = new YouTubeService(labelStatus);
                await youtubeService.DownloadAndMergeVideoAsync(url, videoStream, filePath, labelStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao baixar vídeo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}