﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WolvenKit
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSorted;
        private ListSortDirection listSortDirection;
        private PropertyDescriptor propertyDescriptor;

        protected override bool SupportsSortingCore => true;

        protected override bool IsSortedCore => isSorted;

        protected override PropertyDescriptor SortPropertyCore => propertyDescriptor;

        protected override ListSortDirection SortDirectionCore => listSortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var itemsList = Items as List<T>;
            itemsList.Sort(delegate (T t1, T t2)
            {
                propertyDescriptor = prop;
                listSortDirection = direction;
                isSorted = true;

                var reverse = direction == ListSortDirection.Ascending ? 1 : -1;

                var propertyInfo = typeof(T).GetProperty(prop.Name);
                var value1 = propertyInfo.GetValue(t1, null);
                var value2 = propertyInfo.GetValue(t2, null);

                var comparable = value1 as IComparable;
                if (comparable != null) return reverse * comparable.CompareTo(value2);

                comparable = value2 as IComparable;
                if (comparable != null)
                    return -1 * reverse * comparable.CompareTo(value1);
                return 0;
            });

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
            propertyDescriptor = base.SortPropertyCore;
            listSortDirection = base.SortDirectionCore;
        }
    }
}