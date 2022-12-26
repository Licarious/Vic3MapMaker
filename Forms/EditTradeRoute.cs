using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vic3MapMaker.DataFiles;
using Vic3MapMaker.Utilities;

namespace Vic3MapMaker.Forms
{
    public partial class EditTradeRoute : Form
    {
        TradeRoute tradeRoute;
        Vic3ListStorageUnit lsu;
        MapOperation mapOp;
        public EditTradeRoute(TradeRoute tradeRoute, Vic3ListStorageUnit lsu, MapOperation mapOp) {
            this.tradeRoute = tradeRoute;
            this.lsu = lsu;
            this.mapOp = mapOp;
            InitializeComponent();

            //set targetComboBox to lsu.nations
            targetComboBox.DataSource = lsu.nations.ToList();

            //if tradeRoute.target is not null, set targetComboBox.SelectedItem to tradeRoute.target
            if (tradeRoute.target != null) {
                targetComboBox.SelectedItem = tradeRoute.target;
            }

            //set goodsTextBox to autoComplete from lsu.goods
            goodsTextBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            goodsTextBox.AutoCompleteCustomSource.AddRange(lsu.goods.ToArray());

            //set goodsTextBox to tradeRoute.goods
            goodsTextBox.Text = tradeRoute.goods;

            //set levelTextBox.Text to tradeRoute.level.ToString()
            levelTextBox.Text = tradeRoute.level.ToString();

            //if tradeRoute.isExport is true, set exportRadioButton.Checked to true
            if (tradeRoute.isExport) {
                exportRadioButton.Checked = true;
            }
            else {
                importRadioButton.Checked = true;
            }




        }

        private void SaveButton_Click(object sender, EventArgs e) {

            List<string> errors = new List<string>();
            targetComboBox.BackColor = Color.White;
            goodsTextBox.BackColor = Color.White;
            levelTextBox.BackColor = Color.White;

            //if targetComboBox.SelectedItem is null, add "No target selected" to errors
            if (targetComboBox.SelectedItem == null) {
                errors.Add("No target selected");
                targetComboBox.BackColor = Color.Pink;
            }
            if (goodsTextBox.Text == "") {
                errors.Add("No goods selected");
                goodsTextBox.BackColor = Color.Pink;
            }

            //if levelTextBox.Text is not a positive integer, add "Level must be a positive integer" to errors
            if (!int.TryParse(levelTextBox.Text, out int level) || level < 0) {
                errors.Add("Level must be a positive integer");
                levelTextBox.BackColor = Color.Pink;
            }

            //if errors.Count is not 0, show errors in a message box
            if (errors.Count != 0) {
                MessageBox.Show(string.Join(Environment.NewLine, errors));
                return;
            }

            TradeRoute route = new TradeRoute {
                target = (Nation)targetComboBox.SelectedItem,
                goods = goodsTextBox.Text,
                level = level,
                isExport = exportRadioButton.Checked
            };

            //update tradeRoute
            mapOp.UpdateTradeRoute(route, tradeRoute);

            //close form with DialogResult.OK
            DialogResult = DialogResult.OK;
            Close();


        }

        private void cancelButton_Click(object sender, EventArgs e) {
            //close form with DialogResult.Cancel
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
