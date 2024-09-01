using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace TubeSaver
{
    public partial class FormPrincipal : Form
    {

        private StreamManifest streamManifest;
        public FormPrincipal()
        {
            InitializeComponent();
            buttonProcessar.Enabled = false;
        }
        private Dictionary<string, IStreamInfo> qualityToStreamMap;

        private async void buttonProcessar_Click(object sender, EventArgs e)
        {
            if (streamManifest == null || comboBoxOpcoesQualidade.SelectedItem == null)
            {
                MessageBox.Show("Por favor, carregue as opções de qualidade e selecione uma antes de baixar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "MP4 files (*.mp4)|*.mp4|All files (*.*)|*.*"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveDialog.FileName;
                buttonProcessar.Enabled = false;
                buttonLoadOptions.Enabled = false;

                progressBarPrincipal.Style = ProgressBarStyle.Marquee;
                progressBarPrincipal.MarqueeAnimationSpeed = 30;

                try
                {
                    var youtubeService = new YouTubeService(labelStatusUsuario);

                    // Use o dicionário para obter o stream selecionado
                    if (qualityToStreamMap.TryGetValue(comboBoxOpcoesQualidade.SelectedItem.ToString(), out var selectedStream))
                    {
                        await Task.Run(async () =>
                        {
                            await youtubeService.DownloadAndMergeVideoAsync(textBoxUrlYoutube.Text, selectedStream, filePath, labelStatusUsuario);
                        });

                        MessageBox.Show("Download concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateStatusLabel("Concluído! Estou pronto para o próximo! =)");
                    }
                    else
                    {
                        MessageBox.Show("Qualidade selecionada não está disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao baixar vídeo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBarPrincipal.Style = ProgressBarStyle.Blocks;
                    progressBarPrincipal.MarqueeAnimationSpeed = 100;
                    buttonProcessar.Enabled = true;
                    buttonLoadOptions.Enabled = true;
                }
            }
        }




        private async void buttonLoadOptions_Click(object sender, EventArgs e)
        {
            string url = textBoxUrlYoutube.Text;
            UpdateStatusLabel("Solicitando qualidades disponíveis...");

            using (var loadingForm = new LoadingForm())
            {
                loadingForm.StartPosition = FormStartPosition.CenterScreen;
                loadingForm.Show();

                this.Enabled = false;

                try
                {
                    UpdateStatusLabel("Verificando disponibilidade...");
                    if (!await VideoEstaDisponivelAsync(url))
                    {
                        MessageBox.Show("O Vídeo não está disponível. Verifique a URL e tente novamente.");
                        return;
                    }

                    await CarregarQualidadesAsync(url);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro ao carregar opções de qualidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Enabled = true;
                    loadingForm.Close();
                    UpdateStatusLabel("Selecione a qualidade desejável!");
                }

            }
        }


        private async Task CarregarQualidadesAsync(string url)
        {
            var youtube = new YoutubeClient();
            UpdateStatusLabel("Coletando informações...");
            var video = await youtube.Videos.GetAsync(url);
            streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);

            var videoStreams = streamManifest.GetVideoOnlyStreams()
                                              .Where(stream => stream.Container.Name.Equals("mp4", StringComparison.OrdinalIgnoreCase));

            qualityToStreamMap = new Dictionary<string, IStreamInfo>(); // Inicialize o dicionário

            foreach (var stream in videoStreams)
            {
                qualityToStreamMap[stream.VideoQuality.Label] = stream; // Preencha o dicionário
            }

            comboBoxOpcoesQualidade.Items.Clear();

            foreach (var quality in qualityToStreamMap.Keys)
            {
                comboBoxOpcoesQualidade.Items.Add(quality);
            }

            if (comboBoxOpcoesQualidade.Items.Count > 0)
            {
                comboBoxOpcoesQualidade.SelectedIndex = 0;
                buttonProcessar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Nenhuma opção de qualidade MP4 disponível para este vídeo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonProcessar.Enabled = false;
            }
        }



        public static async Task<bool> VideoEstaDisponivelAsync(string url)
        {
            try
            {
                var youtube = new YoutubeClient();
                var video = await youtube.Videos.GetAsync(url);
                return video != null;
            }
            catch (Exception)
            {
                return false;
            }
        }



        private void buttonLinkedin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/joaoldev/");
        }

        private void buttonGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/DevJoaoLucas");
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