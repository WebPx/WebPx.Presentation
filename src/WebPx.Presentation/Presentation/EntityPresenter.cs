using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPx.Data;
using WebPx.Events;

namespace WebPx.Presentation
{

    public abstract class EntityPresenter<T> : Presenter<IView<T>>, IEntityPreseter<T>
    {
        public EntityPresenter(IView<T> view) : base(view)
        {

        }

        protected override void AttachView(IView<T> view)
        {
            if (view is IGridView<T> gridView)
            {
                gridView.LoadItems += LoadItems;
                gridView.ItemSelected += ItemSelected;
                AttachGridEvents(gridView);
            }
            else if (view is IPagedGridView<T> pagedView)
            {
                pagedView.LoadItems += LoadItems;
                pagedView.ItemSelected += ItemSelected;
                AttachGridEvents(pagedView);
            }

            if (view is IItemView<T> detailsView)
            {
                detailsView.LoadItem += LoadItem;
                AttachDetailsEvents(detailsView);
            }

            if (view is ICreateView<T> createView)
            {
                createView.Create += Create;
                AttachCreateEvents(createView);
            }

            if (view is IEditView<T> editView)
            {
                editView.Update += Update;
                AttachEditEvents(editView);
            }

            if (view is IDeleteView<T> deleteView)
            {
                deleteView.Delete += Delete;
                AttachDeleteEvents(deleteView);
            }
        }

        #region Attach Events
        protected virtual void AttachGridEvents(IPagedGridView<T> pagedView)
        {

        }

        protected virtual void AttachGridEvents(IGridView<T> griView)
        {

        }

        protected virtual void AttachDetailsEvents(IItemView<T> detailsView)
        {

        }

        protected virtual void AttachCreateEvents(ICreateView<T> createView)
        {

        }

        protected virtual void AttachEditEvents(IEditView<T> editView)
        {

        }

        protected virtual void AttachDeleteEvents(IDeleteView<T> deleteView)
        {

        }
        #endregion

        #region Handle Grid View Events
        protected abstract void ItemSelected(object sender, EventArgs e);

        protected abstract void LoadItems(object sender, EventArgs args);
        #endregion

        #region Handle Details View events
        protected abstract void LoadItem(object sender, EventArgs e);
        #endregion

        #region Handle Create View Events
        protected abstract void Create(object sender, CancelEventArgs e);
        #endregion

        #region Handle Edit Events
        protected abstract void Update(object sender, CancelEventArgs e);
        #endregion

        #region Handle Delete Events
        protected abstract void Delete(object sender, CancelEventArgs e);

        #endregion

        public bool Assert(bool evaluation, string eventName, T instance = default(T), dynamic arguments = null)
        {
            return MessageCenter.Assert<T>(evaluation, this, eventName, instance, arguments);
        }
    }
}
