using System;
using System.Windows.Forms;
using PSC2013.ES.Library;

namespace PSC2013.ES.GUI.Components
{
    public partial class DiseaseComponent : UserControl
    {
        private const string DIS_FILTER = "Disease file (*.dis)|*.dis|All files (*.*)|*.*";

        private string _path;

        /// <summary>
        /// Event if the user wants to export the disease.
        /// </summary>
        public event EventHandler<EventArgs> Export;

        /// <summary>
        /// Event if the user wants to import a disease.
        /// </summary>
        public event EventHandler<EventArgs> Import;

        /// <summary>
        /// The selected path of the latest dialog.
        /// </summary>
        public string Path { get { return _path; } }

        public DiseaseComponent()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

            openDisFileDialog.Filter = DIS_FILTER;
            saveDisFileDialog.Filter = DIS_FILTER;

            InitEvents();
        }

        private void InitEvents()
        {
            Btn_export.Click += OnExportClick;
            Btn_import.Click += OnImportClick;
        }
        
        #region events
        private void OnExportClick(object sender, EventArgs e)
        {
            DialogResult dr = saveDisFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _path = saveDisFileDialog.FileName;
                Export.Raise(this, e);
            }
        }

        private void OnImportClick(object sender, EventArgs e)
        {
            DialogResult dr = openDisFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _path = openDisFileDialog.FileName;
                Import.Raise(this, e);
            }
        }
        #endregion events
    }
}