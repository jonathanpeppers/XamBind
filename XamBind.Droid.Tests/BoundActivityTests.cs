using Android.Content;
using Android.Test;
using Android.App;
using Android.OS;
using System;
using NUnit.Framework;
using XamBind.iOS.Tests;
using System.Threading.Tasks;
using Android.Views;
using Android.Widget;

namespace XamBind.Droid.Tests
{
	[TestFixture]
	public class BoundActivityTests
    {
		private TestActivity _activity;
		private TestViewModel _viewModel;
		private View _view;
		private const int Times = 5000;

		[SetUp]
		public void SetUp()
		{
			var context = Application.Context;
			var layoutInflater = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;

			_view = layoutInflater.Inflate(Resource.Layout.Test, null);
			_viewModel = new TestViewModel();
			_activity = new TestActivity
			{
				ViewModel = _viewModel,
			};
			_activity.Bind(context, _view);
		}

        [Test]
        public void PropertyToTextView()
        {
            var textView = _view.FindViewById<TextView>(Resource.Id.Text);
            for (int i = 0; i < Times; i++)
            {
                _viewModel.Text = i.ToString();
                Assert.AreEqual(_viewModel.Text, textView.Text);
            }
        }

        [Test]
        public void ButtonCanClick()
        {
            var button = _view.FindViewById<Button>(Resource.Id.Search);
            for (int i = 0; i < Times; i++)
            {
                _viewModel.CanSearch = !_viewModel.CanSearch;
                Assert.AreEqual(_viewModel.CanSearch, button.Enabled);
            }
        }

        [Test]
        public void ButtonClick()
        {
            var button = _view.FindViewById<Button>(Resource.Id.Search);
            for (int i = 0; i < Times; i++)
            {
                _viewModel.Searched = false;
                button.PerformClick();
                Assert.IsTrue(_viewModel.Searched);
            }
        }

        [Test]
        public void PropertyToTextField()
        {
            var editText = _view.FindViewById<EditText>(Resource.Id.TextField);
            for (int i = 0; i < Times; i++)
            {
                _viewModel.TextField = i.ToString();

                Assert.AreEqual(_viewModel.TextField, editText.Text);
            }
        }

        [Test]
        public void TextFieldToProperty()
        {
            var editText = _view.FindViewById<EditText>(Resource.Id.TextField);
            for (int i = 0; i < Times; i++)
            {
                editText.Text = i.ToString();

                Assert.AreEqual(editText.Text, _viewModel.TextField);
            }
        }
    }
}

