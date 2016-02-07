using Microsoft.Practices.Prism.Regions;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.App.RegionAdapters
{
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackPanelRegionAdapter"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public StackPanelRegionAdapter(IRegionBehaviorFactory factory)
            : base(factory)
        {
        }

        /// <summary>
        /// Template method to adapt the object to an <see cref="T:Microsoft.Practices.Prism.Regions.IRegion" />.
        /// </summary>
        /// <param name="region">The new region being used.</param>
        /// <param name="regionTarget">The object to adapt.</param>
        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        regionTarget.Children.Add(element);
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement element in e.OldItems)
                    {
                        regionTarget.Children.Remove(element);
                    }
                }
            };
        }

        /// <summary>
        /// Template method to create a new instance of <see cref="T:Microsoft.Practices.Prism.Regions.IRegion" />
        /// that will be used to adapt the object.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="T:Microsoft.Practices.Prism.Regions.IRegion" />.
        /// </returns>
        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
