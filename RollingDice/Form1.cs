using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DiceWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();

            // 입력값 검사
            if (!int.TryParse(txtCount.Text, out int totalRolls) || totalRolls <= 0)
            {
                MessageBox.Show("양의 정수를 입력하세요.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] counts = new int[6];
            Random rand = new Random();

            // 주사위 굴리기
            for (int i = 0; i < totalRolls; i++)
            {
                int roll = rand.Next(1, 7); // 1 ~ 6
                counts[roll - 1]++;
            }

            // 결과 테이블 (횟수, 상대도수, %)
            listResult.Items.Add("눈\t횟수\t상대도수\t백분율(%)");

            for (int i = 0; i < 6; i++)
            {
                double freq = (double)counts[i] / totalRolls;
                double percent = freq * 100.0;

                listResult.Items.Add(
                    $"{i + 1}\t{counts[i]}\t{freq:F4}\t{percent:F2}%"
                );
            }

            listResult.Items.Add($"전체 시행 횟수: {totalRolls}");

            // 막대그래프 그리기
            DrawHistogram(counts);
        }

        private void DrawHistogram(int[] counts)
        {
            if (counts == null || counts.Length == 0)
                return;

            if (pictureBoxHistogram.Width <= 0 || pictureBoxHistogram.Height <= 0)
                return;

            int width = pictureBoxHistogram.Width;
            int height = pictureBoxHistogram.Height;

            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int maxCount = counts.Max();
                if (maxCount == 0)
                {
                    if (pictureBoxHistogram.Image != null)
                    {
                        pictureBoxHistogram.Image.Dispose();
                        pictureBoxHistogram.Image = null;
                    }
                    pictureBoxHistogram.Image = bmp;
                    return;
                }

                // 여백
                int marginLeft = 45;
                int marginRight = 10;
                int marginTop = 10;
                int marginBottom = 30;

                int chartWidth = width - marginLeft - marginRight;
                int chartHeight = height - marginTop - marginBottom;

                // 축
                using (Pen axisPen = new Pen(Color.Black, 1))
                {
                    // Y축
                    g.DrawLine(axisPen,
                        marginLeft, marginTop,
                        marginLeft, marginTop + chartHeight);

                    // X축
                    g.DrawLine(axisPen,
                        marginLeft, marginTop + chartHeight,
                        marginLeft + chartWidth, marginTop + chartHeight);
                }

                int yTicks = 5; // y축 눈금 개수

                using (Font font = new Font("맑은 고딕", 8))
                using (Brush textBrush = new SolidBrush(Color.Black))
                using (Pen gridPen = new Pen(Color.LightGray))
                {
                    // y축 눈금 + 보조선
                    for (int i = 0; i <= yTicks; i++)
                    {
                        double ratio = (double)i / yTicks;
                        int yValue = (int)Math.Round(maxCount * ratio);

                        int y = marginTop + chartHeight - (int)(chartHeight * ratio);

                        // 가로 눈금선
                        g.DrawLine(gridPen,
                            marginLeft, y,
                            marginLeft + chartWidth, y);

                        // 눈금 값
                        string label = yValue.ToString();
                        SizeF size = g.MeasureString(label, font);
                        g.DrawString(label, font, textBrush,
                            marginLeft - size.Width - 5,
                            y - size.Height / 2);
                    }

                    // 막대
                    int n = counts.Length;
                    double barWidth = chartWidth / (double)n;
                    double scale = chartHeight / (double)maxCount;

                    using (Brush barBrush = new SolidBrush(Color.SteelBlue))
                    {
                        for (int i = 0; i < n; i++)
                        {
                            int barHeight = (int)Math.Round(counts[i] * scale);

                            float x = (float)(marginLeft + i * barWidth);
                            float y = marginTop + chartHeight - barHeight;
                            float w = (float)(barWidth * 0.7f);
                            float xCenter = x + (float)(barWidth * 0.15f);

                            g.FillRectangle(barBrush, xCenter, y, w, barHeight);

                            // x축 라벨 (눈 1~6)
                            string xLabel = (i + 1).ToString();
                            SizeF size = g.MeasureString(xLabel, font);
                            g.DrawString(
                                xLabel,
                                font,
                                textBrush,
                                x + (float)(barWidth / 2.0) - size.Width / 2,
                                marginTop + chartHeight + 3
                            );
                        }
                    }
                }
            }

            // 이전 이미지 정리 후 새 이미지 설정
            if (pictureBoxHistogram.Image != null)
            {
                pictureBoxHistogram.Image.Dispose();
                pictureBoxHistogram.Image = null;
            }
            pictureBoxHistogram.Image = bmp;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // 리스트 초기화
            listResult.Items.Clear();

            // 그래프 초기화
            if (pictureBoxHistogram.Image != null)
            {
                pictureBoxHistogram.Image.Dispose();
                pictureBoxHistogram.Image = null;
            }

            // 굴릴 횟수 리셋
            txtCount.Text = "1000";
            txtCount.Focus();
            txtCount.SelectAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
