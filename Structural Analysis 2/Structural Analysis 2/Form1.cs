using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Structural_Analysis_2
{
    public partial class Form1 : Form
    {
        private double Result_AB_Con1 = 0;
        private double Result_BA_Con1 = 0;
        private double Result_AB_Con2 = 0;
        private double Result_BA_Con2 = 0;
        private double Result_AB_Con4 = 0;
        private double Result_BA_Con4 = 0;
        private double Result_AB_Con5 = 0;
        private double Result_BA_Con5 = 0;
        private double Result_AB_Con3 = 0;
        private double Result_BA_Con3 = 0;
        private int EI;
        private double P;
        private double q1;
        private double q2;
        private double M;
        private double L;
        private double Beta;
        private double X;
        private double Alpha;
        private double Sy;
        private double Kapa;
        private double Eta;
        private double Fi;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            bool check = Validation();
            if (check)
            {
                EI = Convert.ToInt16(txtEI.Text);
                P = Convert.ToDouble(txtP.Text);
                q1 = Convert.ToDouble(txtq1.Text);
                q2 = Convert.ToDouble(txtq2.Text);
                M = Convert.ToDouble(txtM.Text);
                L = Convert.ToDouble(txtL.Text);
                Beta = Convert.ToDouble(txtBeta.Text);
                X = Convert.ToDouble(txtx.Text);
                Alpha = Convert.ToDouble(txtAlpha.Text);
                Sy = Convert.ToDouble(txtSy.Text);
                Kapa = Convert.ToDouble(txtkapa.Text);
                Eta = Convert.ToDouble(txtEta.Text);
                Fi = Convert.ToDouble(txtFi.Text);

                /// Condition_1

                if (Sy >= Alpha)
                {
                    double Sorat_FEM_AB_Con1 = (M * Beta * (4 * X * Math.Pow(Alpha, 3) * Sy - 3 * X * Math.Pow(Alpha, 2) * Math.Pow(Sy, 2) - 4 * Math.Pow(Alpha, 3) * Beta * Sy + 3 * Math.Pow(Alpha, 2) * Beta * Math.Pow(Sy, 2) - 4 * Math.Pow(Alpha, 3) * X + 4 * Math.Pow(Alpha, 3) * Beta + 3 * Math.Pow(Alpha, 2) * X - 3 * Math.Pow(Alpha, 2) * Beta - 3 * Math.Pow(Sy, 2) * Beta + 4 * Sy * Beta - Beta));
                    double Makhraj_FEM_AB_Con1 = (Math.Pow(X, 2) * Math.Pow(Alpha, 4) - 2 * X * Math.Pow(Alpha, 4) * Beta + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * X * Alpha * Beta - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2));

                    Result_AB_Con1 = (Sorat_FEM_AB_Con1 / Makhraj_FEM_AB_Con1);

                    double Sorat_FEM_BA_Con1 = -((Math.Pow(X, 2) * Math.Pow(Alpha, 4) - 2 * X * Math.Pow(Alpha, 4) * Beta + 4 * X * Math.Pow(Alpha, 3) * Beta * Sy - 3 * X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Sy, 2) + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) * Sy + 3 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) * Math.Pow(Sy, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta * Sy + 6 * X * Alpha * Beta * Math.Pow(Sy, 2) + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) * Sy - 6 * Alpha * Math.Pow(Beta, 2) * Math.Pow(Sy, 2) + 3 * X * Math.Pow(Alpha, 2) * Beta - 3 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 3 * Math.Pow(Beta, 2) * Math.Pow(Sy, 2) - 2 * X * Alpha * Beta + 2 * Alpha * Math.Pow(Beta, 2) - 2 * Math.Pow(Beta, 2) * Sy) * M);
                    double Makhraj_FEM_BA_Con1 = (Math.Pow(X, 2) * Math.Pow(Alpha, 4) - 2 * X * Math.Pow(Alpha, 4) * Beta + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * X * Alpha * Beta - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2));

                    Result_BA_Con1 = (Sorat_FEM_BA_Con1 / Makhraj_FEM_BA_Con1);
                }

                /// Condition_2

                if (Alpha > Sy)
                {
                    double Sorat_FEM_AB_Con2 = -(M * (Math.Pow(X, 2) * Math.Pow(Alpha, 4) - 4 * Math.Pow(X, 2) * Math.Pow(Alpha, 3) * Sy + 3 * Math.Pow(X, 2) * Math.Pow(Alpha, 2) * Math.Pow(Sy, 2) - 2 * X * Math.Pow(Alpha, 4) * Beta + 4 * X * Math.Pow(Alpha, 3) * Beta * Sy - 3 * X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Sy, 2) + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta + 3 * X * Beta * Math.Pow(Sy, 2) + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * X * Alpha * Beta - 4 * X * Beta * Sy - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2)));
                    double Makhraj_FEM_AB_Con2 = (Math.Pow(X, 2) * Math.Pow(Alpha, 4) - 2 * X * Math.Pow(Alpha, 4) * Beta + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * X * Alpha * Beta - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2));

                    Result_AB_Con2 = (Sorat_FEM_AB_Con2 / Makhraj_FEM_AB_Con2);

                    double Sorat_FEM_BA_Con2 = -((4 * X * Math.Pow(Alpha, 3) - 3 * X * Math.Pow(Alpha, 2) * Sy - 4 * Math.Pow(Alpha, 3) * Beta + 3 * Math.Pow(Alpha, 2) * Beta * Sy - 6 * X * Math.Pow(Alpha, 2) + 6 * X * Alpha * Sy + 6 * Math.Pow(Alpha, 2) * Beta - 6 * Alpha * Beta * Sy + 3 * Beta * Sy - 2 * Beta) * M * X * Sy);
                    double Makhraj_FEM_BA_Con2 = (Math.Pow(X, 2) * Math.Pow(Alpha, 4) - 2 * X * Math.Pow(Alpha, 4) * Beta + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * X * Alpha * Beta - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2));

                    Result_BA_Con2 = (Sorat_FEM_BA_Con2 / Makhraj_FEM_BA_Con2);
                }

                /// Coundition_4

                if (Alpha > Eta)
                {
                    double Sorat_FEM_AB_Con4 = -(P * Eta * L * (Math.Pow(X, 2) * Math.Pow(Alpha, 4) - 2 * Math.Pow(X, 2) * Math.Pow(Alpha, 3) * Eta + Math.Pow(X, 2) * Math.Pow(Alpha, 2) * Math.Pow(Eta, 2) - 2 * X * Math.Pow(Alpha, 4) * Beta + 2 * X * Math.Pow(Alpha, 3) * Beta * Eta - X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Eta, 2) + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta + X * Beta * Math.Pow(Eta, 2) + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * X * Alpha * Beta - 2 * X * Beta * Eta - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2)));
                    double Makhraj_FEM_AB_Con4 = (Math.Pow(X, 2) * Math.Pow(Alpha, 4) - 2 * X * Math.Pow(Alpha, 4) * Beta + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * X * Alpha * Beta - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2));

                    Result_AB_Con4 = (Sorat_FEM_AB_Con4 / Makhraj_FEM_AB_Con4);

                    double Sorat_FEM_BA_Con4 = -((2 * X * Math.Pow(Alpha, 3) - X * Math.Pow(Alpha, 2) * Eta - 2 * Math.Pow(Alpha, 3) * Beta + Math.Pow(Alpha, 2) * Beta * Eta - 3 * X * Math.Pow(Alpha, 2) + 2 * X * Alpha * Eta + 3 * Math.Pow(Alpha, 2) * Beta - 2 * Alpha * Beta * Eta + Eta * Beta - Beta) * P * Math.Pow(Eta, 2) * L * X);
                    double Makhraj_FEM_BA_Con4 = (Math.Pow(Alpha, 4) * Math.Pow(X, 2) - 2 * X * Math.Pow(Alpha, 4) * Beta + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * X * Alpha * Beta - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2));

                    Result_BA_Con4 = (Sorat_FEM_BA_Con4 / Makhraj_FEM_BA_Con4);
                }

                /// Condition_5

                if (Eta >= Alpha)
                {
                    double Sorat_FEM_AB_Con5 = (L * P * Beta * (2 * X * Math.Pow(Alpha, 3) * Math.Pow(Eta, 2) - X * Math.Pow(Alpha, 2) * Math.Pow(Eta, 3) - 2 * Math.Pow(Alpha, 3) * Beta * Math.Pow(Eta, 2) + Math.Pow(Alpha, 2) * Beta * Math.Pow(Eta, 3) - 4 * Math.Pow(Alpha, 3) * X * Eta + 4 * Math.Pow(Alpha, 3) * Beta * Eta + 2 * Math.Pow(Alpha, 3) * X + 3 * Math.Pow(Alpha, 2) * X * Eta - 2 * Math.Pow(Alpha, 3) * Beta - 3 * Math.Pow(Alpha, 2) * Beta * Eta - Beta * Math.Pow(Eta, 3) - 2 * Math.Pow(Alpha, 2) * X + 2 * Math.Pow(Alpha, 2) * Beta + 2 * Beta * Math.Pow(Eta, 2) - Eta * Beta));
                    double Makhraj_FEM_AB_Con5 = (Math.Pow(Alpha, 4) * Math.Pow(X, 2) - 2 * X * Math.Pow(Alpha, 4) * Beta + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * X * Alpha * Beta - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2));

                    Result_AB_Con5 = (Sorat_FEM_AB_Con5 / Makhraj_FEM_AB_Con5);

                    double Sorat_FEM_BA_Con5 = -((Math.Pow(Alpha, 4) * Math.Pow(X, 2) * Eta - 2 * X * Math.Pow(Alpha, 4) * Beta * Eta + 2 * X * Math.Pow(Alpha, 3) * Beta * Math.Pow(Eta, 2) - X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Eta, 3) + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) * Eta - 2 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) * Math.Pow(Eta, 2) + Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) * Math.Pow(Eta, 3) - Math.Pow(X, 2) * Math.Pow(Alpha, 4) + 2 * X * Math.Pow(Alpha, 4) * Beta - 3 * X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Eta, 2) + 2 * X * Alpha * Beta * Math.Pow(Eta, 3) - Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 3 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) * Math.Pow(Eta, 2) - 2 * Alpha * Math.Pow(Beta, 2) * Math.Pow(Eta, 3) - 2 * X * Math.Pow(Alpha, 3) * Beta + 3 * X * Math.Pow(Alpha, 2) * Beta * Eta + 2 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 3 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) * Eta + Math.Pow(Beta, 2) * Math.Pow(Eta, 3) + X * Math.Pow(Alpha, 2) * Beta - 2 * X * Alpha * Beta * Eta - Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 2 * Alpha * Math.Pow(Beta, 2) * Eta - Math.Pow(Beta, 2) * Math.Pow(Eta, 2)) * P * L);
                    double Makhraj_FEM_BA_Con5 = (Math.Pow(X, 2) * Math.Pow(Alpha, 4) - 2 * X * Math.Pow(Alpha, 4) * Beta + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * X * Math.Pow(Alpha, 2) * Beta + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * X * Alpha * Beta - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2));

                    Result_BA_Con5 = (Sorat_FEM_BA_Con5 / Makhraj_FEM_BA_Con5);
                }

                /// Condition_3

                if ((Alpha * L) >= ((Kapa * L) + (Fi * L)) && q2 >= q1)
                {
                    double X1 = (1 / (-q2 + q1)) * (Kapa * L * q1 - Kapa * L * q2 + q1 * Fi * L) + Math.Pow(((Kapa * Math.Pow(L, 2) * Math.Pow(Fi, 2) * Math.Pow(q1, 2) - Kapa * Math.Pow(L, 2) * Math.Pow(Fi, 2) * q1 * q2 + Math.Pow(L, 2) * Math.Pow(q1, 2) * Math.Pow(Fi, 3) - Math.Pow(Fi, 3) * Math.Pow(L, 2) * q1 * q2 + -Math.Pow(Fi, 2) * Math.Pow(L, 2) * q1 * q2 + 2 * L * q2 * (0.33 * Math.Pow(Fi, 2) * L + 0.5 * Fi * L * Kapa - 0.5 * Fi * L) * Fi * q1 - 2 * L * q2 * (0.33 * Math.Pow(Fi, 2) * L + 0.5 * Fi * L * Kapa - 0.5 * Fi * L) * Fi * q2)), 0.5);
                    double X2 = (1 / (-q2 + q1)) * (Kapa * L * q1 - Kapa * L * q2 + q1 * Fi * L) - Math.Pow(((Kapa * Math.Pow(L, 2) * Math.Pow(Fi, 2) * Math.Pow(q1, 2) - Kapa * Math.Pow(L, 2) * Math.Pow(Fi, 2) * q1 * q2 + Math.Pow(L, 2) * Math.Pow(q1, 2) * Math.Pow(Fi, 3) - Math.Pow(Fi, 3) * Math.Pow(L, 2) * q1 * q2 + -Math.Pow(Fi, 2) * Math.Pow(L, 2) * q1 * q2 + 2 * L * q2 * (0.33 * Math.Pow(Fi, 2) * L + 0.5 * Fi * L * Kapa - 0.5 * Fi * L) * Fi * q1 - 2 * L * q2 * (0.33 * Math.Pow(Fi, 2) * L + 0.5 * Fi * L * Kapa - 0.5 * Fi * L) * Fi * q2)), 0.5);

                    double result_X = Cheeck_PositiveValue(X1, X2);

                    double A = -q2 * (((Math.Pow(Fi, 2) * L) / 3) + ((Fi * L * Kapa) / 2) - ((Fi * L) / 2)) - (q1 * ((Math.Pow(Fi, 2) * L) / 2) + ((Fi * L * Kapa) / 2) - ((Fi * L) / 2));
                    double B = q2 * (((Math.Pow(Fi, 2) * L) / 3) + ((Fi * L * Kapa) / 2)) + (q1 * ((Math.Pow(Fi, 2) * L) / 6) + ((Fi * L * Kapa) / 2));

                    double Sorat_FEM_AB_Con3 = (-20 * Math.Pow(B, 2) * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) + 20 * Math.Pow(B, 2) * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta + 30 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 4) - 40 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Fi - 30 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) * Beta + 40 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta * Fi - 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 5) + 30 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 4) * Fi - 20 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Math.Pow(Fi, 2) + 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 5) * Beta - 30 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) * Beta * Fi + 20 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta * Math.Pow(Fi, 2) + 8 * A * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) - 8 * A * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta - 10 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) - 24 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Fi + 10 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta + 24 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta * Fi + 20 * A * Kapa * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Fi - 12 * A * Kapa * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) - 20 * A * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta * Fi + 12 * A * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) + 8 * B * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) - 8 * B * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta + 10 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) + 24 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Fi - 10 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta - 24 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta * Fi - 30 * B * Kapa * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 4) + 20 * B * Kapa * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Fi + 24 * B * Kapa * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) + 30 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) * Beta - 20 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta * Fi - 24 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) + 10 * B * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 5) - 30 * B * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 4) * Fi + 10 * B * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Math.Pow(Fi, 2) + 8 * B * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Math.Pow(Fi, 3) - 10 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 5) * Beta + 30 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) * Beta * Fi - 10 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta * Math.Pow(Fi, 2) - 8 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 3) - 21 * A * Math.Pow(Kapa, 2) * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) + 21 * A * Math.Pow(Kapa, 2) * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta - 10 * A * Kapa * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 3) + 18 * A * Kapa * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Fi + 10 * A * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Beta - 18 * A * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta * Fi - 20 * A * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 3) * Fi + 12 * A * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) + 20 * A * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Beta * Fi - 12 * A * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) - 20 * Math.Pow(B, 2) * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Alpha * Beta + 10 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta - 40 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * result_X * Alpha * Beta * Fi + 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta + 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta * Fi - 20 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Alpha * Beta * Math.Pow(Fi, 2) - 18 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) + 18 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta + 9 * B * Math.Pow(Kapa, 2) * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) - 9 * B * Math.Pow(Kapa, 2) * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta + 30 * B * Kapa * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) - 36 * B * Kapa * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Fi - 30 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta + 36 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta * Fi - 10 * B * Kapa * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 3) + 18 * B * Kapa * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Fi + 10 * B * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Beta - 18 * B * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta * Fi - 10 * B * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 4) + 30 * B * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Fi - 18 * B * Math.Pow(L, 2) * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) + 20 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) * Beta - 30 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta * Fi + 18 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) - 10 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) - 10 * B * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 3) * Fi + 9 * B * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) + 10 * B * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Beta * Fi - 9 * B * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) + 8 * A * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * result_X * Beta - 24 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Beta * Fi - 12 * A * Kapa * Math.Pow(L, 2) * result_X * Beta * Math.Pow(Fi, 2) + 33 * A * Kapa * Math.Pow(result_X, 4) * Math.Pow(Alpha, 2) - 33 * A * Kapa * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Beta + 6 * A * Math.Pow(result_X, 4) * Math.Pow(Alpha, 2) * Fi - 6 * A * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Beta * Fi + 20 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * result_X * Alpha * Beta - 20 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta + 20 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Alpha * Beta * Fi + 8 * B * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * result_X * Beta + 20 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Alpha * Beta + 24 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Beta * Fi - 10 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta + 40 * B * Kapa * Math.Pow(L, 2) * result_X * Alpha * Beta * Fi + 24 * B * Kapa * Math.Pow(L, 2) * result_X * Beta * Math.Pow(Fi, 2) - 9 * B * Kapa * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) + 9 * B * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta + 3 * B * Kapa * Math.Pow(result_X, 4) * Math.Pow(Alpha, 2) - 3 * B * Kapa * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Beta - 50 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Beta - 10 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta * Fi + 20 * B * Math.Pow(L, 2) * result_X * Alpha * Beta * Math.Pow(Fi, 2) + 8 * B * Math.Pow(L, 2) * result_X * Beta * Math.Pow(Fi, 3) + 40 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) + 10 * B * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 3) - 9 * B * L * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Fi - 10 * B * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Beta + 9 * B * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta * Fi + 3 * B * Math.Pow(result_X, 4) * Math.Pow(Alpha, 2) * Fi - 3 * B * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Beta * Fi - 10 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Beta - 21 * A * Math.Pow(Kapa, 2) * L * Math.Pow(result_X, 2) * Beta + 20 * A * Kapa * Math.Pow(L, 2) * result_X * Beta * Fi + 18 * A * Kapa * L * Math.Pow(result_X, 2) * Beta * Fi + 12 * A * L * Math.Pow(result_X, 2) * Beta * Math.Pow(Fi, 2) - 28 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Beta + 9 * B * Math.Pow(Kapa, 2) * L * Math.Pow(result_X, 2) * Beta - 20 * B * Kapa * Math.Pow(L, 2) * result_X * Alpha * Beta - 56 * B * Kapa * Math.Pow(L, 2) * result_X * Beta * Fi + 18 * B * Kapa * L * Math.Pow(result_X, 2) * Beta * Fi + 80 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Beta - 20 * B * Math.Pow(L, 2) * result_X * Alpha * Beta * Fi - 28 * B * Math.Pow(L, 2) * result_X * Beta * Math.Pow(Fi, 2) - 60 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 9 * B * L * Math.Pow(result_X, 2) * Beta * Math.Pow(Fi, 2) - 3 * B * Math.Pow(result_X, 4) * Math.Pow(Alpha, 2) + 3 * B * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Beta - 10 * A * Kapa * L * Math.Pow(result_X, 2) * Beta + 33 * A * Kapa * Math.Pow(result_X, 3) * Beta - 20 * A * L * Math.Pow(result_X, 2) * Beta * Fi + 6 * A * Math.Pow(result_X, 3) * Beta * Fi + 30 * B * Kapa * Math.Pow(L, 2) * result_X * Beta - 19 * B * Kapa * L * Math.Pow(result_X, 2) * Beta + 3 * B * Kapa * Math.Pow(result_X, 3) * Beta - 40 * B * Math.Pow(L, 2) * result_X * Alpha * Beta + 30 * B * Math.Pow(L, 2) * result_X * Beta * Fi + 40 * B * Math.Pow(L, 2) * Alpha * Math.Pow(Beta, 2) - 19 * B * L * Math.Pow(result_X, 2) * Beta * Fi + 3 * B * Math.Pow(result_X, 3) * Beta * Fi - 10 * B * Math.Pow(L, 2) * Math.Pow(Beta, 2) + 10 * B * L * Math.Pow(result_X, 2) * Beta - 3 * B * Math.Pow(result_X, 3) * Beta);
                    double Makhraj_FEM_AB_BA_Con3 = (10 * L * (Math.Pow(result_X, 2) * Math.Pow(Alpha, 4) - 2 * result_X * Math.Pow(Alpha, 4) * Beta + Math.Pow(Alpha, 4) * Math.Pow(Beta, 2) + 4 * result_X * Math.Pow(Alpha, 3) * Beta - 4 * Math.Pow(Alpha, 3) * Math.Pow(Beta, 2) - 6 * result_X * Math.Pow(Alpha, 2) * Beta + 6 * Math.Pow(Alpha, 2) * Math.Pow(Beta, 2) + 4 * result_X * Alpha * Beta - 4 * Alpha * Math.Pow(Beta, 2) + Math.Pow(Beta, 2)));

                    Result_AB_Con3 = (Sorat_FEM_AB_Con3 / Makhraj_FEM_AB_BA_Con3);

                    double Sorat_FEM_BA_Con3 = -((-20 * Math.Pow(B, 2) * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) + 20 * Math.Pow(B, 2) * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta + 30 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) - 40 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Fi - 30 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 4) * Beta + 40 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta * Fi - 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 5) + 30 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) * Fi - 20 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Math.Pow(Fi, 2) + 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 5) * Beta - 30 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 4) * Beta * Fi + 20 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta * Math.Pow(Fi, 2) + 8 * A * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) - 8 * A * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta - 10 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) - 24 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Fi + 10 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta + 24 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Fi + 20 * A * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Fi - 12 * A * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) - 20 * A * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta * Fi + 12 * A * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) + 40 * Math.Pow(B, 2) * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) - 40 * Math.Pow(B, 2) * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta - 50 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) + 80 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Fi + 50 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta - 80 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Fi + 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) - 50 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Fi + 40 * Math.Pow(B, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) - 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 4) * Beta + 50 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta * Fi - 40 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) + 8 * B * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) - 8 * B * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta + 10 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) + 24 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Fi - 10 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta - 24 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Fi - 30 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) + 20 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Fi + 24 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) + 30 * B * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 4) * Beta - 20 * B * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta * Fi - 24 * B * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) + 10 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 5) - 30 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) * Fi + 10 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Math.Pow(Fi, 2) + 8 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Math.Pow(Fi, 3) - 10 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 5) * Beta + 30 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 4) * Beta * Fi - 10 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta * Math.Pow(Fi, 2) - 8 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 3) - 16 * A * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * result_X * Alpha + 16 * A * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * Alpha * Beta + 15 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) + 48 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Alpha * Fi - 15 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta - 48 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Alpha * Beta * Fi - 21 * A * Math.Pow(Kapa, 2) * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) + 21 * A * Math.Pow(Kapa, 2) * L * result_X * Math.Pow(Alpha, 2) * Beta - 30 * A * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Fi + 24 * A * Kapa * Math.Pow(L, 2) * result_X * Alpha * Math.Pow(Fi, 2) + 30 * A * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Fi - 24 * A * Kapa * Math.Pow(L, 2) * Alpha * Beta * Math.Pow(Fi, 2) - 10 * A * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) + 18 * A * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Fi + 10 * A * Kapa * L * result_X * Math.Pow(Alpha, 3) * Beta - 18 * A * Kapa * L * result_X * Math.Pow(Alpha, 2) * Beta * Fi - 20 * A * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Fi + 12 * A * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) + 20 * A * L * result_X * Math.Pow(Alpha, 3) * Beta * Fi - 12 * A * L * result_X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) + 20 * Math.Pow(B, 2) * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Alpha * Beta - 10 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta + 40 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * Alpha * Beta * Fi - 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta - 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Fi + 20 * Math.Pow(B, 2) * Math.Pow(L, 2) * Alpha * Beta * Math.Pow(Fi, 2) - 16 * B * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * result_X * Alpha + 16 * B * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * Alpha * Beta - 43 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) - 48 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Alpha * Fi + 43 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta + 48 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Alpha * Beta * Fi + 9 * B * Math.Pow(Kapa, 2) * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) - 9 * B * Math.Pow(Kapa, 2) * L * result_X * Math.Pow(Alpha, 2) * Beta + 80 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) - 86 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Fi - 48 * B * Kapa * Math.Pow(L, 2) * result_X * Alpha * Math.Pow(Fi, 2) - 80 * B * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta + 86 * B * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Fi + 48 * B * Kapa * Math.Pow(L, 2) * Alpha * Beta * Math.Pow(Fi, 2) - 10 * B * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) + 18 * B * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Fi + 10 * B * Kapa * L * result_X * Math.Pow(Alpha, 3) * Beta - 18 * B * Kapa * L * result_X * Math.Pow(Alpha, 2) * Beta * Fi - 10 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 4) + 80 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 3) * Fi - 43 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) - 16 * B * Math.Pow(L, 2) * result_X * Alpha * Math.Pow(Fi, 3) + 10 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 4) * Beta - 80 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta * Fi + 43 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) + 16 * B * Math.Pow(L, 2) * Alpha * Beta * Math.Pow(Fi, 3) - 10 * B * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) * Fi + 9 * B * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Math.Pow(Fi, 2) + 10 * B * L * result_X * Math.Pow(Alpha, 3) * Beta * Fi - 9 * B * L * result_X * Math.Pow(Alpha, 2) * Beta * Math.Pow(Fi, 2) - 8 * A * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * Beta + 24 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Beta * Fi + 42 * A * Math.Pow(Kapa, 2) * L * Math.Pow(result_X, 2) * Alpha - 42 * A * Math.Pow(Kapa, 2) * L * result_X * Alpha * Beta + 12 * A * Kapa * Math.Pow(L, 2) * Beta * Math.Pow(Fi, 2) + 15 * A * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) - 36 * A * Kapa * L * Math.Pow(result_X, 2) * Alpha * Fi - 15 * A * Kapa * L * result_X * Math.Pow(Alpha, 2) * Beta + 36 * A * Kapa * L * result_X * Alpha * Beta * Fi + 33 * A * Kapa * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) - 33 * A * Kapa * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta + 30 * A * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Fi - 24 * A * L * Math.Pow(result_X, 2) * Alpha * Math.Pow(Fi, 2) - 30 * A * L * result_X * Math.Pow(Alpha, 2) * Beta * Fi + 24 * A * L * result_X * Alpha * Beta * Math.Pow(Fi, 2) + 6 * A * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Fi - 6 * A * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta * Fi - 10 * Math.Pow(B, 2) * Kapa * Math.Pow(L, 2) * Alpha * Beta + 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta - 10 * Math.Pow(B, 2) * Math.Pow(L, 2) * Alpha * Beta * Fi - 8 * B * Math.Pow(Kapa, 3) * Math.Pow(L, 2) * Beta + 36 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * result_X * Alpha - 56 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Alpha * Beta - 24 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Beta * Fi - 18 * B * Math.Pow(Kapa, 2) * L * Math.Pow(result_X, 2) * Alpha + 18 * B * Math.Pow(Kapa, 2) * L * result_X * Alpha * Beta - 45 * B * Kapa * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) + 72 * B * Kapa * Math.Pow(L, 2) * result_X * Alpha * Fi + 55 * B * Kapa * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta - 112 * B * Kapa * Math.Pow(L, 2) * Alpha * Beta * Fi - 24 * B * Kapa * Math.Pow(L, 2) * Beta * Math.Pow(Fi, 2) + 6 * B * Kapa * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) - 36 * B * Kapa * L * Math.Pow(result_X, 2) * Alpha * Fi - 6 * B * Kapa * L * result_X * Math.Pow(Alpha, 2) * Beta + 36 * B * Kapa * L * result_X * Alpha * Beta * Fi + 3 * B * Kapa * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) - 3 * B * Kapa * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta - 45 * B * Math.Pow(L, 2) * result_X * Math.Pow(Alpha, 2) * Fi + 36 * B * Math.Pow(L, 2) * result_X * Alpha * Math.Pow(Fi, 2) + 10 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 3) * Beta + 55 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta * Fi - 56 * B * Math.Pow(L, 2) * Alpha * Beta * Math.Pow(Fi, 2) - 8 * B * Math.Pow(L, 2) * Beta * Math.Pow(Fi, 3) + 10 * B * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 3) + 6 * B * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Fi - 18 * B * L * Math.Pow(result_X, 2) * Alpha * Math.Pow(Fi, 2) - 10 * B * L * result_X * Math.Pow(Alpha, 3) * Beta - 6 * B * L * result_X * Math.Pow(Alpha, 2) * Beta * Fi + 18 * B * L * result_X * Alpha * Beta * Math.Pow(Fi, 2) + 3 * B * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) * Fi - 3 * B * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta * Fi + 5 * A * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Beta + 21 * A * Math.Pow(Kapa, 2) * L * result_X * Beta - 10 * A * Kapa * Math.Pow(L, 2) * Beta * Fi - 18 * A * Kapa * L * result_X * Beta * Fi - 66 * A * Kapa * Math.Pow(result_X, 3) * Alpha + 66 * A * Kapa * Math.Pow(result_X, 2) * Alpha * Beta - 12 * A * L * result_X * Beta * Math.Pow(Fi, 2) - 12 * A * Math.Pow(result_X, 3) * Alpha * Fi + 12 * A * Math.Pow(result_X, 2) * Alpha * Beta * Fi + 23 * B * Math.Pow(Kapa, 2) * Math.Pow(L, 2) * Beta - 9 * B * Math.Pow(Kapa, 2) * L * result_X * Beta + 10 * B * Kapa * Math.Pow(L, 2) * Alpha * Beta + 46 * B * Kapa * Math.Pow(L, 2) * Beta * Fi + 18 * B * Kapa * L * Math.Pow(result_X, 2) * Alpha - 18 * B * Kapa * L * result_X * Alpha * Beta - 18 * B * Kapa * L * result_X * Beta * Fi - 6 * B * Kapa * Math.Pow(result_X, 3) * Alpha + 6 * B * Kapa * Math.Pow(result_X, 2) * Alpha * Beta - 10 * B * Math.Pow(L, 2) * Math.Pow(Alpha, 2) * Beta + 10 * B * Math.Pow(L, 2) * Alpha * Beta * Fi + 23 * B * Math.Pow(L, 2) * Beta * Math.Pow(Fi, 2) - 15 * B * L * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) + 18 * B * L * Math.Pow(result_X, 2) * Alpha * Fi + 15 * B * L * result_X * Math.Pow(Alpha, 2) * Beta - 18 * B * L * result_X * Alpha * Beta * Fi - 9 * B * L * result_X * Beta * Math.Pow(Fi, 2) - 3 * B * Math.Pow(result_X, 3) * Math.Pow(Alpha, 2) - 6 * B * Math.Pow(result_X, 3) * Alpha * Fi + 3 * B * Math.Pow(result_X, 2) * Math.Pow(Alpha, 2) * Beta + 6 * B * Math.Pow(result_X, 2) * Alpha * Beta * Fi + 5 * A * Kapa * L * result_X * Beta - 33 * A * Kapa * Math.Pow(result_X, 2) * Beta + 10 * A * L * result_X * Beta * Fi - 6 * A * Math.Pow(result_X, 2) * Beta * Fi - 15 * B * Kapa * Math.Pow(L, 2) * Beta + 14 * B * Kapa * L * result_X * Beta - 3 * B * Kapa * Math.Pow(result_X, 2) * Beta - 15 * B * Math.Pow(L, 2) * Beta * Fi + 14 * B * L * result_X * Beta * Fi + 6 * B * Math.Pow(result_X, 3) * Alpha - 6 * B * Math.Pow(result_X, 2) * Alpha * Beta - 3 * B * Math.Pow(result_X, 2) * Beta * Fi - 5 * B * L * result_X * Beta + 3 * B * Math.Pow(result_X, 2) * Beta) * result_X);

                    Result_BA_Con3 = (Sorat_FEM_BA_Con3 / Makhraj_FEM_AB_BA_Con3);
                }

                ///// Result

                double Result_AB = Result_AB_Con1 + Result_AB_Con2 + Result_AB_Con4 + Result_AB_Con5 + Result_AB_Con3;

                double Result_BA = Result_BA_Con1 + Result_BA_Con2 + Result_BA_Con4 + Result_BA_Con5 + Result_BA_Con3;


                lblFEM_AC.Text = Result_AB.ToString();
                lblFEM_CA.Text = Result_BA.ToString();

            }
        }

        private void txtP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
                e.Handled = true;
        }

        private void txtP_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            txt.BackColor = Color.Green;
            txt.ForeColor = Color.White;
        }

        private void txtP_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            txt.BackColor = Color.White;
            txt.ForeColor = Color.Black;
        }

        private bool Validation()
        {
            if (txtEI.Text == "")
            {
                txtEI.Select();
                return false;
            }
            if (txtP.Text == "")
            {
                txtP.Select();
                return false;
            }
            if (txtq1.Text == "")
            {
                txtq1.Select();
                return false;
            }
            if (txtq2.Text == "")
            {
                txtq2.Select();
                return false;
            }
            if (txtM.Text == "")
            {
                txtM.Select();
                return false;
            }
            if (txtL.Text == "")
            {
                txtL.Select();
                return false;
            }
            if (txtBeta.Text == "")
            {
                txtBeta.Select();
                return false;
            }
            if (txtx.Text == "")
            {
                txtx.Select();
                return false;
            }
            if (txtAlpha.Text == "")
            {
                txtAlpha.Select();
                return false;
            }
            if (txtSy.Text == "")
            {
                txtSy.Select();
                return false;
            }
            if (txtkapa.Text == "")
            {
                txtkapa.Select();
                return false;
            }
            if (txtEta.Text == "")
            {
                txtEta.Select();
                return false;
            }
            if (txtFi.Text == "")
            {
                txtFi.Select();
                return false;
            }

            CheckParameters Cheeck = new CheckParameters();

            if (Cheeck.ShowDialog() != DialogResult.Yes)
                return false;

            return true;
        }

        private void btnCalculate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnCalculate_Click(null, null);
        }

        public double Cheeck_PositiveValue(double C1, double C2)
        {
            if (C1 > 0)
                return C1;

            else if (C2 > 0)
                return C2;
            else
                return -1;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            txtEI.Text = "";
            txtP.Text = "";
            txtq1.Text = "";
            txtq2.Text = "";
            txtM.Text = "";
            txtL.Text = "";
            txtBeta.Text = "";
            txtx.Text = "";
            txtAlpha.Text = "";
            txtSy.Text = "";
            txtkapa.Text = "";
            txtEta.Text = "";
            txtFi.Text = "";
            lblFEM_AC.Text = "";
            lblFEM_CA.Text = "";
            Result_AB_Con1 = 0;
            Result_BA_Con1 = 0;
            Result_AB_Con2 = 0;
            Result_BA_Con2 = 0;
            Result_AB_Con4 = 0;
            Result_AB_Con5 = 0;
            Result_BA_Con5 = 0;
            Result_AB_Con3 = 0;
            Result_BA_Con3 = 0;
            EI = 0;
            P = 0;
            q1 = 0;
            q2 = 0;
            M = 0;
            L = 0;
            Beta = 0;
            X = 0;
            Alpha = 0;
            Sy = 0;
            Kapa = 0;
            Eta = 0;
            Fi = 0;
            txtEI.Select();
        }
    }
}