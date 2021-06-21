using System;
using System.Drawing;
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

        #region LIMPA OS TEXTBOX DAS ENTRADAS DOS DADOS
        private void limpa_textBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        #endregion

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
            if (op == 2 )  //Quadrado ou circulo ou hexágono
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
                label7.Visible = true;
                textBox5.Visible = true;
            }
        }
        #endregion

        #region OPÇÃO DA FIGURA ESCOLHIDA COLOCANDO OS LABEL E TEXTBOX PARA DIGITAR INFORMAÇÕES
        private void Opcao_escolhida(object sender, EventArgs e)
        {
            limpa_textBox();
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

            Graphics g = pictureBox1.CreateGraphics();

            // Limpa o desenho anterior caso haja
            g.Clear(Color.LightSkyBlue);

            textBox7.Text = "";

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
                label7.Text = "Informe o valor do lado: ";
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

            if (opcao == 6) // Hexágono
            {
                Esconde();
                label13.Text = "Hexágono";
                textBox8.Text = "Hexágono:" + Environment.NewLine + "Figura plana é formada pela junção" +
                                                Environment.NewLine + "de seis triângulos equiláteros";
                                                
                Mostra(2);
                label2.Text = "Informe o valor do lado: ";
                textBox1.Select();
            }
        }
        #endregion

        #region DESENHO DO TRIANGULO
        public void desenha_triangulo()
        {

            //pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + @"imagens\img1.jpg");

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

                //textBox7.Text = "";
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


                //calculo da área e do polígono do triângulo
                textBox4.Text = ((int.Parse(textBox1.Text) * int.Parse(textBox2.Text)) / 2).ToString();
                textBox3.Text = (int.Parse(textBox2.Text) * 3).ToString();

                // coloca no textbox as formulas da figura selecionada
                textBox7.Text = Environment.NewLine + "Área = (base x altura)/2." + Environment.NewLine + "Perímetro = 3 x altura.";


                // define o objeto Graphics no picturebox
                Graphics g = pictureBox1.CreateGraphics();

                // define a cor do lápis e largura e o polígono
                g.DrawPolygon(new Pen(Color.Black, 4), pontos);

                // desenha as linhas internas do triângulo
                Pen lapis1 = new Pen(Color.Yellow, 3);
                g.DrawLine(lapis1, new Point(x + basex / 2, y + 5), new Point(x + basex / 2, y + altura - 5));

                //escreve os textos no triângulo
                g.DrawString("base", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 2 - 30, y + altura);
                g.DrawString("altura", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 2, y + altura / 2 - 20);

                // limpa o objeto Graphics
                g.Dispose();
            }
        }
        #endregion

        #region DESENHA RETANGULO
        public void desenha_retangulo()
        {
            //pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + @"imagens\img1.jpg");

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
                
                //textBox7.Text = "";
                basex = int.Parse(textBox1.Text) * 40;
                altura = int.Parse(textBox2.Text) * 40;

                x = (400 - basex) / 2;
                y = (400 - altura) / 2;

                Rectangle retang = new Rectangle(x, y, basex, altura);

                //calculo da área e do polígono do retângulo
                textBox4.Text = (int.Parse(textBox1.Text) * int.Parse(textBox2.Text)).ToString();       // área
                textBox3.Text = (2 * (int.Parse(textBox1.Text) + int.Parse(textBox2.Text))).ToString(); // polígono

                // coloca no textbox as formulas da figura selecionada
                textBox7.Text = Environment.NewLine + "Área = base x altura." + Environment.NewLine + "Perímetro = 2 x (base + altura).";

                // define o objeto Graphics no picturebox
                Graphics g = pictureBox1.CreateGraphics();

                // Limpa o desenho anterior caso haja
                //g.Clear(Color.Gainsboro);



                // define a cor do lápis e largura e o retang
                g.DrawRectangle(new Pen(Color.Black, 4), retang);

                //desenhador.DrawRectangle(lapis, retang);
                g.DrawString("altura", new Font("Arial", 16), new SolidBrush(Color.Black), x, y + altura / 2 - 20);
                g.DrawString("base", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 2 - 30, y + altura);

                // limpa o objeto Graphics
                g.Dispose();
            }
        }

        #endregion

        #region DESENHO DO QUADRADO
        public void desenha_quadrado()
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
                //textBox7.Text = "";
                basex = int.Parse(textBox1.Text) * 40;

                x = (400 - basex) / 2;

                // define o quadrado de acordo com o lado informado através de um retângulo
                Rectangle retang = new Rectangle(x, x, basex, basex);

                //calculo da área e do polígono do quadrado. Mostra também o valor do lado
                textBox4.Text = (int.Parse(textBox1.Text) * int.Parse(textBox1.Text)).ToString();
                textBox3.Text = (int.Parse(textBox1.Text) * 4).ToString();
                label10.Text = "Lado:";
                textBox9.Text = (int.Parse(textBox1.Text)).ToString();

                //// coloca no textbox as formulas da figura selecionada
                textBox7.Text = Environment.NewLine + "Área = lado x lado." + Environment.NewLine + "Perímetro = 4 x lado.";

                // define o objeto Graphics no picturebox
                Graphics g = pictureBox1.CreateGraphics();

                // Limpa o desenho anterior caso haja
                //g.Clear(Color.Gainsboro);
               
                // define a cor do lápis e largura e o retang
                g.DrawRectangle(new Pen(Color.Black, 4), retang);

                // escreve o lado do quadrado
                g.DrawString("L = " + textBox1.Text, new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 2 - 30, x + basex + 10);

                // limpa o objeto Graphics
                g.Dispose();
            }
        }
        #endregion

        #region DESENHO DO CÍRCULO
        private void desenha_circulo()
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
                //textBox7.Text = "";
                basex = int.Parse(textBox1.Text) * 40;

                x = (400 - basex) / 2;

                // define o quadrado de acordo com o raio informado através de um retângulo
                Rectangle retang = new Rectangle(x, x, basex, basex);

                //calculo da área e do perímeto do círculo
                textBox4.Text = (3.1415 * (int.Parse(textBox1.Text) * int.Parse(textBox1.Text))).ToString("N2");
                textBox3.Text = (2 * 3.1415 * (int.Parse(textBox1.Text))).ToString("N2");
                label10.Text = "Raio:";
                textBox9.Text = (int.Parse(textBox1.Text)).ToString();


                // coloca no textbox as formulas da figura selecionada
                textBox7.Text = Environment.NewLine + "Área = Pi x (r^2)." + Environment.NewLine + "Perímetro = 2 x Pi x r.";

                // define o objeto Graphics no picturebox
                Graphics g = pictureBox1.CreateGraphics();

                // Limpa o desenho anterior caso haja
                //g.Clear(Color.Gainsboro);

                // define a cor do lápis e largura e o retang
                g.DrawEllipse(new Pen(Color.Black, 4), retang);

                // escreve o raio do círculo
                g.DrawString("R = " + textBox1.Text, new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 2 - 35, x + basex + 10);

                // limpa o objeto Graphics
                g.Dispose();

            }

        }

        #endregion

        #region DESENHO DO TRAPÉZIO
        private void desenha_trapezio()
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
            if (textBox1.Text == textBox2.Text)
            {
                MessageBox.Show("Base maior igual a base menor vira quadrado. Digite valores diferentes.");
                textBox1.Select();
            }
            else
            {

                //textBox7.Text = "";
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

                // LINHAS INTERNAS DO TRAPÉZIO
                double ALT = Convert.ToDouble(textBox6.Text);
                double BM = Convert.ToDouble(textBox1.Text);
                double Bm = Convert.ToDouble(textBox2.Text);

                //calculo da área
                textBox4.Text = (((BM + Bm) * ALT) / 2).ToString();
                // CALCULO DO LADO
                double lado = int.Parse(textBox5.Text);
                textBox9.Text = textBox5.Text; // lado.ToString();
                // calculo do perímetro
                textBox3.Text = (BM + Bm + lado + lado).ToString();

                //// coloca no textbox as formulas da figura selecionada
                textBox7.Text = Environment.NewLine + "Área = ((B + b) * altura) /2." +
                                Environment.NewLine + "Perímetro = B + b + L1 + L2";
                                //Environment.NewLine + "Lado = RAIZ((h*h) + ((BM - Bm) / 2) ^2 )";

                // define o objeto Graphics no picturebox
                Graphics g = pictureBox1.CreateGraphics();

                // Limpa o desenho anterior caso haja
                //g.Clear(Color.Gainsboro);

                // define a cor do lápis e largura e o trapézio
                g.DrawPolygon(new Pen(Color.Black, 4), pontos);


                // ESCREVE OS LADOS E BASE DA FIGURA
                if (BM > Bm) // SE BASE MAIOR FOR MAIOR QUE BASE MENOR.....
                {

                    g.DrawString("base maior", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 3 - 15, y + altura);
                    g.DrawString("base menor", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 3 - 15, 400 - (y + altura) - 30);
                }
                if (BM < Bm)// SE BASE MAIOR FOR MENOR QUE BASE MAIOR.....
                {

                    g.DrawString("base menor", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 3 - 5, y + altura -30);
                    g.DrawString("base maior", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex / 3 - 5, 400 - (y + altura) - 30);
                }

                g.DrawString("L1", new Font("Arial", 16), new SolidBrush(Color.Black), x - 20, 190);
                g.DrawString("L2", new Font("Arial", 16), new SolidBrush(Color.Black), x + basex -5, 190);
                g.DrawString("h", new Font("Arial", 16), new SolidBrush(Color.Black), z + 7, 190);

                g.DrawLine(new Pen(Color.Black, 4), z, 400 - (y + altura), z, y + altura);

                // limpa o objeto Graphics
                g.Dispose();
            }
        }
        #endregion

        #region DESENHO DO LOSANGO
        private void desenha_losango()
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

                //textBox7.Text = "";
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

                //calculo da área do losango
                textBox4.Text = ((int.Parse(textBox1.Text) * int.Parse(textBox2.Text)) / 2).ToString();

                // calculo do lado do losango
                double diagmaior = Convert.ToDouble(textBox1.Text);
                double diagmenor = Convert.ToDouble(textBox2.Text);
                double LADO = Math.Sqrt(Math.Pow((diagmaior / 2), 2) + Math.Pow(diagmenor / 2, 2));

                // calculo do perimetro do losango
                textBox3.Text = (LADO * 4).ToString("N2");
                textBox9.Text = LADO.ToString("N2");

                // coloca no textbox as formulas da figura selecionada
                textBox7.Text = Environment.NewLine + "Área = (DM x Dm)/2." +
                Environment.NewLine + "Lado = RAIZ((DM/2)^2 + (Dm/2)^2)" +
                Environment.NewLine + "Perímetro = 4 x lado.";

                // define o objeto Graphics no picturebox
                Graphics g = pictureBox1.CreateGraphics();

                // Limpa o desenho anterior caso haja
                //g.Clear(Color.Gainsboro);

                //desenha a figura
                g.DrawPolygon(new Pen(Color.Black,4), pontos);

                // DESENHA AS LINHAS INTERNAS DO LOSANGO
                Pen lapis1 = new Pen(Color.Blue, 3);
                Pen lapis2 = new Pen(Color.Green, 3);

                g.DrawLine(lapis2, new Point(200, y + 5), new Point(200, y + DM - 5)); // diagonal maior
                g.DrawLine(lapis1, new Point(x + 4, DM / 2 + y), new Point(x + Dm - 4, DM / 2 + y)); // diagonal menor

                // ESCREVE AS PALAVRAS DIAGONAL MAIOR E DIAGONAL MENOR DENTRO DO LOSANGO
                g.DrawString("Dm", new Font("Arial", 16), new SolidBrush(Color.Blue), 160, 200);
                g.DrawString("DM", new Font("Arial", 16), new SolidBrush(Color.Green), 200, 160);

                // limpa o objeto Graphics
                g.Dispose();
            }

        }
        #endregion

        #region DESENHO DO HEXÁGONO
        private void desenha_hexagono()
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha com o valor do lado.");
                textBox1.Select();
            }
            else
             if (Convert.ToDouble(textBox1.Text) < 2 || Convert.ToDouble(textBox1.Text) > 8 )
               
            {
                MessageBox.Show("Preencha com valores entre 2 e 8.");
                textBox1.Select();
            }
            else
            {
                //textBox7.Text = "";
                int lado = int.Parse(textBox1.Text) * 40 / 2;

                x = y = (400 - lado * 2) / 2;

                // Create points that define polygon.
                Point point1 = new Point(x, y + lado);
                Point point2 = new Point(200 - lado + lado / 2, y);
                Point point3 = new Point(x + lado + lado / 2, y);
                Point point4 = new Point(x + lado * 2, y + lado);
                Point point5 = new Point(x + lado + lado / 2, y + lado * 2);
                Point point6 = new Point(200 - lado + lado / 2, y + lado * 2);

                Point[] pontos =
                         {
                point1,
                point2,
                point3,
                point4,
                point5,
                point6
            };


                //calculo da área do hexágono
                double LADO = (int.Parse(textBox1.Text));
                textBox4.Text = ((3 * Math.Pow(lado, 2) * Math.Sqrt(3)) / 2).ToString("N2");
                // calculo do perimetro do losango
                textBox3.Text = (LADO * 6).ToString();
                textBox9.Text = LADO.ToString();

                // coloca no textbox as formulas da figura selecionada
                textBox7.Text = Environment.NewLine + "Área = ((3xlado^2 x raiz(3))/2." +
                Environment.NewLine + "Perímetro = 6 x lado.";

                // define o objeto Graphics no picturebox
                Graphics g = pictureBox1.CreateGraphics();

                // Limpa o desenho anterior caso haja
                //g.Clear(Color.Gainsboro);

                // desenha a figura
                g.DrawPolygon(new Pen(Color.Black,4), pontos);

                // TRAÇOS DAS LINHAS INTERNAS
                Pen lapis1 = new Pen(Color.Blue, 3);
                g.DrawLine(lapis1, new Point(x, y + lado), new Point(x + lado * 2, y + lado)); // linha AD
                g.DrawLine(lapis1, new Point(200 - lado + lado / 2, y), new Point(x + lado + lado / 2, y + lado * 2)); // linha BE
                g.DrawLine(lapis1, new Point(x + lado + lado / 2, y), new Point(200 - lado + lado / 2, y + lado * 2));  // linha CF

                // ESCREVE AS PALAVRAS DIAGONAL MAIOR E DIAGONAL MENOR DENTRO DO LOSANGO
                g.DrawString("L", new Font("Arial", 16), new SolidBrush(Color.Blue), 200 - lado /2, 200);

                // limpa o objeto Graphics
                g.Dispose();
            }
        }
        #endregion

        #region MÉTODO DE QUANDO CLICA O BOTÃO DESENHAR PARA DESENHAR AS FIGURAS
        public void BtnDesenhar_Click(object sender, EventArgs e)
        {

            Graphics g = pictureBox1.CreateGraphics();
            // Limpa o desenho anterior caso haja
            g.Clear(Color.LightSkyBlue);

            if (opcao == 0) 
            {
                desenha_triangulo();
            }

            if (opcao == 1) 
            {
                desenha_retangulo();
            }

            if (opcao == 2) 
            {
                desenha_quadrado();
            }

            if (opcao == 3) 
            {
                desenha_circulo();
            }

            if (opcao == 4) 
            {
                desenha_trapezio();
            }

            if (opcao == 5)
            {
                desenha_losango();
            }

            if (opcao == 6)
            {
                desenha_hexagono();
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
