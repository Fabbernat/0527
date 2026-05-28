using autoform.Models;

namespace autoform;

public partial class MainForm : Form
{
    private readonly DataGridView dgvAutok = new();
    private readonly ListBox lbAutok = new();
    private readonly TextBox tbEv = new();
    private readonly Button btnBetolt = new();
    private readonly Button btnBezar = new();
    private readonly Label lblLista = new();
    private readonly Label lblEv = new();

    private List<Auto> autok = [];

    public MainForm()
    {
        Text = "Autók";
        Width = 750;
        Height = 500;
        StartPosition = FormStartPosition.CenterScreen;

        InitializeControls();
    }

    private void InitializeControls()
    {
        dgvAutok.Left = 20;
        dgvAutok.Top = 20;
        dgvAutok.Width = 690;
        dgvAutok.Height = 230;
        dgvAutok.ReadOnly = true;
        dgvAutok.AllowUserToAddRows = false;
        dgvAutok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        lblLista.Text = "Gyártási lista:";
        lblLista.Left = 20;
        lblLista.Top = 270;
        lblLista.Width = 100;

        lbAutok.Left = 20;
        lbAutok.Top = 295;
        lbAutok.Width = 180;
        lbAutok.Height = 120;

        lblEv.Text = "Év:";
        lblEv.Left = 240;
        lblEv.Top = 300;
        lblEv.Width = 30;

        tbEv.Left = 280;
        tbEv.Top = 296;
        tbEv.Width = 80;
        tbEv.TextChanged += TbEv_TextChanged;

        btnBetolt.Text = "Betölt";
        btnBetolt.Left = 460;
        btnBetolt.Top = 390;
        btnBetolt.Width = 100;
        btnBetolt.Click += BtnBetolt_Click;

        btnBezar.Text = "Bezár";
        btnBezar.Left = 590;
        btnBezar.Top = 390;
        btnBezar.Width = 100;
        btnBezar.Click += BtnBezar_Click;

        Controls.Add(dgvAutok);
        Controls.Add(lblLista);
        Controls.Add(lbAutok);
        Controls.Add(lblEv);
        Controls.Add(tbEv);
        Controls.Add(btnBetolt);
        Controls.Add(btnBezar);
    }

    private void BtnBetolt_Click(object? sender, EventArgs e)
    {
        OpenFileDialog dialog = new()
        {
            Filter = "CSV fájlok (*.csv)|*.csv|Minden fájl (*.*)|*.*",
            Title = "Autók adatainak betöltése"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            autok = Auto.Beolvas(dialog.FileName);
            dgvAutok.DataSource = null;
            dgvAutok.DataSource = autok;

            SzuresEvSzerint();
        }
    }

    private void TbEv_TextChanged(object? sender, EventArgs e)
    {
        SzuresEvSzerint();
    }

    private void SzuresEvSzerint()
    {
        lbAutok.Items.Clear();

        if (!int.TryParse(tbEv.Text, out int ev))
        {
            return;
        }

        var talalatok = autok
            .Where(auto => auto.GyartasiEv == ev)
            .Select(auto => $"{auto.Marka} {auto.Modell}");

        foreach (var autoNev in talalatok)
        {
            lbAutok.Items.Add(autoNev);
        }
    }

    private void BtnBezar_Click(object? sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "Valóban ki szeretne lépni?",
            "Kilépés",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
        {
            Close();
        }
    }
}