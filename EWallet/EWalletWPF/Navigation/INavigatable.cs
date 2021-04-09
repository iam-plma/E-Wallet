using System;

namespace EWalletWPF.Navigation
{
    public interface INavigatable<TObject> where TObject : Enum
    {
        public TObject Type { get; }

        public void ClearSensitiveData();
        public void UpdateView();
    }
}
