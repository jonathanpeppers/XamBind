using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using NUnit.Framework;

namespace XamBind.iOS.Tests
{
	[TestFixture]
    public class BoundControllerTests
    {
		private TestController _controller;
		private TestViewModel _viewModel;
		private const int Times = 5000;

		[SetUp]
		public void SetUp()
		{
			_viewModel = new TestViewModel();

			var storyboard = UIStoryboard.FromName("TestStoryboard", NSBundle.MainBundle);
			_controller = storyboard.InstantiateViewController("TestController") as TestController;
			_controller.ViewModel = _viewModel;
			_controller.View.ToString(); //Load view
		}

		[Test]
		public void PropertyToLabel()
		{
			for (int i = 0; i < Times; i++)
			{
				_viewModel.Text = i.ToString();
            	
				Assert.AreEqual(_viewModel.Text, _controller.GetLabel().Text);
			}
		}

		[Test]
		public void ButtonCanClick()
		{
			for (int i = 0; i < Times; i++)
			{
				_viewModel.CanSearch = !_viewModel.CanSearch;
            	
				Assert.AreEqual(_viewModel.CanSearch, _controller.GetButton().Enabled);
			}
		}

		[Test]
		public void ButtonClick()
		{
			for (int i = 0; i < Times; i++)
			{
				_viewModel.Searched = false;
				_controller.Click();
				Assert.IsTrue(_viewModel.Searched);
			}
		}

		[Test]
		public void PropertyToTextField()
		{
			var textField = _controller.GetTextField();
			for (int i = 0; i < Times; i++)
			{
				_viewModel.TextField = i.ToString();

				Assert.AreEqual(_viewModel.TextField, textField.Text);
			}
		}

		[Test]
		public void TextFieldToProperty()
		{
			var textField = _controller.GetTextField();

			for (int i = 0; i < Times; i++)
			{
				textField.Text = i.ToString();

				var notification = NSNotification.FromName(UITextField.TextFieldTextDidChangeNotification, textField);
				NSNotificationCenter.DefaultCenter.PostNotification(notification);

				Assert.AreEqual(textField.Text, _viewModel.TextField);
			}
		}
    }
}

