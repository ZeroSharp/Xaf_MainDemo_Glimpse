using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using System;

namespace MainDemo.Module.Controllers {
	public partial class ClearFieldsController : ViewController {
		public ClearFieldsController() {
			InitializeComponent();
			RegisterActions(components);
		}

		private void ClearFieldsAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
			foreach(PropertyEditor item in ((DetailView)View).GetItems<PropertyEditor>()) {
				if(item.AllowEdit) {
					try {
						item.PropertyValue = null;
					}
					catch(IntermediateMemberIsNullException) {
					    item.Refresh();
					}
				}
			}
		}

		private void ClearFieldsController_Activated(object sender, EventArgs e) {
			ClearFieldsAction.Enabled.SetItemValue("EditMode", ((DetailView)View).ViewEditMode == ViewEditMode.Edit);
			((DetailView)View).ViewEditModeChanged += new EventHandler<EventArgs>(ClearFieldsController_ViewEditModeChanged);
		}
		void ClearFieldsController_ViewEditModeChanged(object sender, EventArgs e) {
			ClearFieldsAction.Enabled.SetItemValue("EditMode", ((DetailView)View).ViewEditMode == ViewEditMode.Edit);
		}
	}
}
