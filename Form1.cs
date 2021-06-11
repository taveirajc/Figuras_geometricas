using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Areas_de_Figuras
{

    public partial class Form1 : Form
    {
        int opcao = -1;
        int altura, basex, basem, x, y, z;
 
        public Form1()
        {
            InitializeComponent();
            Esconde();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // INICIA OS RADIOBUTTON DESMARCADOS
            RbCirculo.AutoCheck = true;
            RbLosango.AutoCheck = true;
            RbQuadrado.AutoCheck = true;
            RbRetangulo.AutoCheck = true;
            RbTrapezio.AutoCheck = true;
            RbTriangulo.AutoCheck = true;
            label9.Visible = false;
        }

        #region ESCONDE OS TEXTBOX E TÍTULOS DOS DADOS DE INFORMAÇÃO
        private void Esconde()
        {
            label2.Visible = false;
            label3.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox6.Visible = false;
            textBox5.Visible = false;
        }
        #endregion

        #region  MOSTRA OS TEXTBOX E TITULOS DE ACORDO COM A FIGURA SELECIONADA
        private void Mostra(int op)
        { 
            if (op == 1)  // Triângulo ou retângulo ou losango
            {
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
            }
            if (op == 2 )  //Quadrado ou circulo
            {
                label2.Visible = true;
                textBox1.Visible = true;
            }
            if (op == 4) // Trapézio
            {
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label8.Visible = true;
                textBox6.Visible = true;
            }
        }
        #endregion

        #region OPÇÃO DA FIGURA ESCOLHIDA COLOCANDO OS LABEL E TEXTBOX PARA DIGITAR INFORMAÇÕES
        private void Opcao_escolhida(object sender, EventArgs e)
        {
            label9.Visible = true;
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is RadioButton radioB)
                {
                    if (radioB.Checked)
                    {
                        opcao = radioB.TabIndex; // PEGA O ÍNDICE DA FIGURA ESCOLHIDA 
                    }
                }
            }

            // DESENHO DO TRIÂNGULO
            if (opcao == 0) // triângulo
            {
                Esconde();
                label13.Text = "Triângulo";
                textBox8.Text = "Triângulo:" + Environment.NewLine + "Figura fechada e plana formada por" +
                                                Environment.NewLine + "três lados.";    
                
                Mostra(1); // MOSTRA OS TEXTBOX DOS DADOS PARA DIGITAR OS DADOS
                label2.Text = "Informe o valor da base: ";
                label3.Text = "Informe o valor da altura: ";
                textBox1.Select();
            }

            // DESENHO DO RETANGULO
            if (opcao == 1) // retângulo
            {
                Esconde();
                label13.Text = "Retângulo";
                textBox8.Text = "Retângulo:" + Environment.NewLine + "Figura fechada e plana formada por" + 
                                                Environment.NewLine + "quatro lados. Dois deles são congruentes" + 
                                                Environment.NewLine + "e os outros dois também.";
                Mostra(1);
                label2.Text = "Informe o valor da base: ";
                label3.Text = "Informe o valor da altura: ";
                textBox1.Select();
            }

            // DESENHO DO QUADRADO
            if (opcao == 2) // quadrado
            {
                Esconde();
                label13.Text = "Quadrado";
                textBox8.Text = "Quadrado:" + Environment.NewLine + "Figura fechada e plana limitada por" +
                                                Environment.NewLine + "quatro lados congruentes." +
                                                Environment.NewLine + "(possuem a mesma medida).";
                Mostra(2);
                label2.Text = "Informe o valor do lado: "; 
                textBox1.Select();
            }

            // DESENHO DO CÍRCULO
            if (opcao == 3) // círculo
            {
                Esconde();
                label13.Text = "Círculo";
                textBox8.Text = "Quadrado:" + Environment.NewLine + "Figura fechada e plana limitada por" +
                                                Environment.NewLine + "uma linha curva chamada" +
                                                Environment.NewLine + "circunferência.";
                Mostra(2);
                label2.Text = "Informe o valor do raio: ";
                textBox1.Select();
            }

            //DESENHO DO TRAPÉZIO
            if (opcao == 4) // trapézio
            {
                Esconde();
                label13.Text = "Trapézio";
                textBox8.Text = "Trapézio:" + Environment.NewLine + "Figura fechada e plana que possui dois" +
                                                Environment.NewLine + "lados e bases paralelas, onde uma é" +
                                                Environment.NewLine + "maior e outra menor.";
                Mostra(4);
                label2.Text = "Informe o valor da base maior: ";
                label3.Text = "Informe o valor da base menor: ";
                label8.Text = "Informe o valor da altura: ";
                textBox1.Select();
            }

            // DESENHO DO LOSANGO
            if (opcao == 5) // Losango
            {
                Esconde();
                label13.Text = "Losango";
                textBox8.Text = "Losango:" + Environment.NewLine + "Figura fechada e plana composta de " +
                                                Environment.NewLine + "4 lados. Essa figura apresenta lados e " +
                                                Environment.NewLine + "ângulos opostos congruentes e paralelos.";
                Mostra(1);
                label2.Text = "Informe o valor da diagonal maior: (DM)";
                label3.Text = "Informe o valor da diagonal menor: (Dm)";
                textBox1.Select();
            }
        }
        #endregion

        #region MÉTODO DE QUANDO CLICA O BOTÃO DESENHAR PARA DESENHAR AS FIGURAS
        private void BtnDesenhar_Click(object sender, EventArgs e)
        {

            Bitmap folha = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics desenhador = Graphics.FromImage(folha);
            desenhador.Clear(Color.Gainsboro);
            pictureBox1.BackgroundImage = folha;

            Pen lapis = new Pen(Color.Black, 4);

            if (opcao == 0) // triângulo
            {
                if (textBox1.Text == "" || textBox2.Text == "") 
                {
                    MessageBox.Show("Preencha as duas informações solicitadas.");
                    textBox1.Select();
                }
                else
                if (Convert.ToDouble(textBox1.Text) < 2 || Convert.ToDouble(textBox1.Text) > 8 ||
                    Convert.ToDouble(textBox2.Text) < 2 || Convert.ToDouble(textBox2.Text) > 8)
                { 
                    MessageBox.Show("Preencha com valores entre 2 e 8.");
                    textBox1.Select();
                }
                else
                {
                    
                    textBox7.Text = "";
                    basex = Convert.ToInt32(textBox1.Text) * 40;
                    altura = Convert.ToInt32(textBox2.Text) * 40;

                    x = (400 - basex) / 2;
                    y = (400 - altura) / 2;

                    Point[] pontos =
                    {
                        new Point(x, y + altura),
                        new Point(x + basex /2, y),
                        new Point(x + basex, y + altura)
                    };

                    desenhador.DrawPolygon(lapis, pontos);

                    Pen lapis1 = new Pen(Color.Yellow, 3);
                    desenhador.DrawLine(lapis1, new Point(x + basex / 2, y + 5), new Point(x + basex / 2, y + altura - 5));

                    desenhador.DrawString("base", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 2 - 30, y + altura);
                    desenhador.DrawString("altura", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 2, y + altura / 2 - 20);

                    //calculo da área e do polígono do quadrado
                    textBox4.Text = ((int.Parse(textBox1.Text) * int.Parse(textBox2.Text)) / 2).ToString();
                    textBox3.Text = (int.Parse(textBox2.Text) * 3).ToString();

                    // coloca no textbox as formulas da figura selecionada
                    textBox7.Text = Environment.NewLine + "Área = (base x altura)/2." + Environment.NewLine + "Perímetro = 3 x altura.";                  
                }
            }
        

            if (opcao == 1) // retângulo
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Preencha as duas informações solicitadas.");
                    textBox1.Select();
                }
                else
                if (Convert.ToDouble(textBox1.Text) < 2 || Convert.ToDouble(textBox1.Text) > 8 ||
                    Convert.ToDouble(textBox2.Text) < 2 || Convert.ToDouble(textBox2.Text) > 8)
                {
                    MessageBox.Show("Preencha com valores entre 2 e 8.");
                    textBox1.Select();
                }
                else
                {
                    textBox7.Text = "";
                    basex = int.Parse(textBox1.Text) * 40;
                    altura = int.Parse(textBox2.Text) * 40;

                    x = (400 - basex) / 2;
                    y = (400 - altura) / 2;

                    Rectangle retang = new Rectangle(x, y, basex, altura);
                    desenhador.DrawRectangle(lapis, retang);
                    desenhador.DrawString("altura", new Font("Arial", 16), new SolidBrush(Color.Black), x, y + altura / 2 - 20);
                    desenhador.DrawString("base", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 2 - 30, y + altura);

                    //calculo da área e do polígono do retângulo

                    textBox4.Text = (int.Parse(textBox1.Text) * int.Parse(textBox2.Text)).ToString();       // área
                    textBox3.Text = (2 * (int.Parse(textBox1.Text) + int.Parse(textBox2.Text))).ToString(); // polígono

                    // coloca no textbox as formulas da figura selecionada
                    textBox7.Text = Environment.NewLine + "Área = base x altura." + Environment.NewLine + "Perímetro = 2 x (base + altura).";
                }
            }


            if (opcao == 2) // quadrado
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Preencha o valor solicitado.");
                    textBox1.Select();
                }
                else
                if (Convert.ToDouble(textBox1.Text) < 2 || Convert.ToDouble(textBox1.Text) > 8)
                {
                    MessageBox.Show("Preencha com valores entre 2 e 8.");
                    textBox1.Select();
                }
                else
                {
                    textBox7.Text = "";
                    basex = int.Parse(textBox1.Text) * 40;

                    x = (400 - basex) / 2;
                    //int y = (400 - altura) / 2;

                    Rectangle retang = new Rectangle(x, x, basex, basex);
                    desenhador.DrawRectangle(lapis, retang);
                    desenhador.DrawString("L = " + textBox1.Text, new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 2 - 35, x + basex + 10);

                    //calculo da área e do polígono do quadrado
                    textBox4.Text = (int.Parse(textBox1.Text) * int.Parse(textBox1.Text)).ToString();
                    textBox3.Text = (int.Parse(textBox1.Text) * 4).ToString();

                    // coloca no textbox as formulas da figura selecionada
                    textBox7.Text = Environment.NewLine + "Área = lado x lado." + Environment.NewLine + "Perímetro = 4 x lado.";
                }
             }


            if (opcao == 3) // Círculo
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Preencha o valor solicitado.");
                    textBox1.Select();
                }
                else
                if (Convert.ToDouble(textBox1.Text) < 2 || Convert.ToDouble(textBox1.Text) > 8)
                {
                    MessageBox.Show("Preencha com valores entre 2 e 8.");
                    textBox1.Select();
                }
                else
                {
                    textBox7.Text = "";
                    basex = int.Parse(textBox1.Text) * 40;

                    x = (400 - basex) / 2;


                    Rectangle retang = new Rectangle(x, x, basex, basex);
                    desenhador.DrawEllipse(lapis, retang);
                    desenhador.DrawString("R = " + textBox1.Text, new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 2 - 35, x + basex + 10);

                    //calculo da área e do perímeto do círculo
                    textBox4.Text = (3.1415 * (int.Parse(textBox1.Text) * int.Parse(textBox1.Text))).ToString();
                    textBox3.Text = (2 * 3.1415 * (int.Parse(textBox1.Text))).ToString();

                    // coloca no textbox as formulas da figura selecionada
                    textBox7.Text = Environment.NewLine + "Área = Pi x (r^2)." + Environment.NewLine + "Perímetro = 2 x Pi x r.";
                }
            }
            

            if (opcao == 4) // trapézio
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Preencha as informações solicitadas.");
                    textBox1.Select();
                }
                else
                if (Convert.ToDouble(textBox1.Text) < 2 || Convert.ToDouble(textBox1.Text) > 8 ||
                    Convert.ToDouble(textBox2.Text) < 2 || Convert.ToDouble(textBox2.Text) > 8 ||
                    Convert.ToDouble(textBox6.Text) < 2 || Convert.ToDouble(textBox6.Text) > 8)
                {
                    MessageBox.Show("Preencha com valores entre 2 e 8.");
                    textBox1.Select();
                }
                else
                {
                    textBox7.Text = "";
                    basex = Convert.ToInt32(textBox1.Text) * 40;
                    basem = Convert.ToInt32(textBox2.Text) * 40;
                    altura = Convert.ToInt32(textBox6.Text) * 40;

                    x = (400 - basex) / 2;
                    y = (400 - altura) / 2;
                    z = (400 - basem) / 2;

                    Point[] pontos =
                    {
                        new Point(x, y + altura),
                        new Point(z, 400 - (y + altura)),
                        new Point(z + basem, 400 - (y + altura)),
                        new Point(x + basex, y + altura),
                    };

                    desenhador.DrawPolygon(lapis, pontos);

                    // LINHAS INTERNAS DO TRAPÉZIO
                    double ALT = Convert.ToDouble(textBox6.Text);
                    double BM = Convert.ToDouble(textBox1.Text);
                    double Bm = Convert.ToDouble(textBox2.Text);

                    // ESCREVE OS LADOS E BASE DA FIGURA
                    desenhador.DrawString("base maior", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 3 - 15, y + altura);
                    desenhador.DrawString("base menor", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 3 - 15, 400 - (y + altura) - 30);
                    desenhador.DrawString("L1", new Font("Arial", 16), new SolidBrush(Color.Black), x - 30, 190);
                    desenhador.DrawString("L2", new Font("Arial", 16), new SolidBrush(Color.Black), x + 280, 190);

                    //calculo da área
                    textBox4.Text = (((BM + Bm) * ALT) / 2).ToString();

                    // CALCULO DO LADO
                    double lado = Math.Sqrt(Math.Pow(ALT, 2) + Math.Pow(((BM - Bm) / 2), 2));
                    textBox9.Text = lado.ToString("N2");
                    // calculo do perímetro
                    textBox3.Text = (BM + Bm + lado + lado).ToString("N2");

                    textBox7.Text = Environment.NewLine + "Área = ((B + b) * altura) /2." +
                        Environment.NewLine + "Perímetro = B + b + L1 + L2" +
                        Environment.NewLine + "Lado = RAIZ((h*h) + ((BM - Bm) / 2) ^2 )";

                }
            }


            if (opcao == 5) // losango
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Preencha as duas informações solicitadas.");
                    textBox1.Select();
                }
                else
                if (Convert.ToDouble(textBox1.Text) < 2 || Convert.ToDouble(textBox1.Text) > 8 ||
                    Convert.ToDouble(textBox2.Text) < 2 || Convert.ToDouble(textBox2.Text) > 8)
                {
                    MessageBox.Show("Preencha com valores entre 2 e 8.");
                    textBox1.Select();
                }
                else
                {
                    textBox7.Text = "";
                    int DM = Convert.ToInt32(textBox1.Text) * 40;
                    int Dm = Convert.ToInt32(textBox2.Text) * 40;

                    x = (400 - Dm) / 2;
                    y = (400 - DM) / 2;

                    // PNTOS PARA FORMAR O LOSANGO
                    Point[] pontos =
                    {
                    new Point(200, y),
                    new Point(x , DM/2 + y),
                    new Point(200, y + DM),
                    new Point(x + Dm, DM/2 + y),
                    };

                    desenhador.DrawPolygon(lapis, pontos);

                    // DESENHA AS LINHAS INTERNAS DO LOSANGO
                    Pen lapis1 = new Pen(Color.White, 3);
                    Pen lapis2 = new Pen(Color.Yellow, 3);

                    desenhador.DrawLine(lapis2, new Point(200, y + 5), new Point(200, y + DM - 5)); // diagonal maior
                    desenhador.DrawLine(lapis1, new Point(x + 5, DM / 2 + y), new Point(x + Dm - 5, DM / 2 + y)); // diagonal menor

                    // ESCREVE A DIAGONAL MAIOR E DIAGONAL MENOR DENTRO DO LOSANGO
                    desenhador.DrawString("Dm", new Font("Arial", 16), new SolidBrush(Color.White), 160, 200);
                    desenhador.DrawString("DM", new Font("Arial", 16), new SolidBrush(Color.Yellow), 200, 160);

                    //calculo da área do losango
                    textBox4.Text = ((int.Parse(textBox1.Text) * int.Parse(textBox2.Text)) / 2).ToString();

                    // calculo do lado do losango
                    double diagmaior = Convert.ToDouble(textBox1.Text);
                    double diagmenor = Convert.ToDouble(textBox2.Text);
                    double LADO = Math.Sqrt(Math.Pow((diagmaior/2),2) + Math.Pow(diagmenor/2,2));

                    // calculo do perimetro do losango
                    textBox3.Text = (LADO * 4).ToString("N2");
                    textBox9.Text = LADO.ToString("N2");

                    // coloca no textbox as formulas da figura selecionada
                    textBox7.Text = Environment.NewLine + "Área = (DM x Dm)/2." +
                    Environment.NewLine + "Lado = RAIZ((DM/2)^2 + (Dm/2)^2)" +
                    Environment.NewLine + "Perímetro = 4 x lado.";
                }
            }          
        }
        #endregion

        #region SAÍDA DO PROGRAMA
        private void BtnSair_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

    }
}
