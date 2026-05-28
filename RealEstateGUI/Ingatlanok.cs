using RealEstate.DbMysqlModels;
using Microsoft.EntityFrameworkCore;

namespace RealEstateGUI
{
    public partial class Ingatlanok : Form
    {
        private readonly RealestateContext _db = new();
        private readonly BindingSource _sellerBindingSource = new();

        public Ingatlanok()
        {
            InitializeComponent();

            Text = "Ingatlanok";
            MinimumSize = new Size(500, 250);

            Load += MainForm_Load;
            loadAdsButton.Click += LoadAdsButton_Click;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            var sellers = _db.Sellers
                .OrderBy(s => s.Name)
                .ToList();

            _sellerBindingSource.DataSource = sellers;

            sellersListBox.DataSource = _sellerBindingSource;
            sellersListBox.DisplayMember = "Name";
            sellersListBox.ValueMember = "Id";

            sellerPhoneValueLabel.DataBindings.Clear();

            

            sellerPhoneValueLabel.DataBindings.Add(
                "Text",
                _sellerBindingSource,
                "Phone"
            );
        }

        private void LoadAdsButton_Click(object? sender, EventArgs e)
        {
            if (_sellerBindingSource.Current is not Seller selectedSeller)
                return;

            int count = _db.Realestates
                .Count(ad => ad.SellerId == selectedSeller.Id);

            adCountValueLabel.Text = count.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
