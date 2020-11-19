using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace GoogleBooksChallenge.Core.ViewModels
{
    public abstract class BaseViewModel<TParameter, TResult> : BaseViewModelResult<TResult>, IMvxViewModel<TParameter, TResult>
        where TParameter : notnull
        where TResult : notnull
    {
        public BaseViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {

        }
        public abstract void Prepare(TParameter parameter);
    }
}
