using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FFImageLoading.Cross;
using System;

namespace PlaygroundTest
{
    [Register("playgroundtest." + nameof(CustomShapeView))]
    public class CustomShapeView : RelativeLayout
    {
        private MvxCachedImageView _imageView;

        protected CustomShapeView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer) { }

        public CustomShapeView(Context context) : base(context)
        {
            Init(context);
        }

        public CustomShapeView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context, attrs);
        }

        public CustomShapeView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs,
            defStyleAttr)
        {
            Init(context, attrs);
        }

        public CustomShapeView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context,
            attrs, defStyleAttr, defStyleRes)
        {
            Init(context, attrs);
        }

        private void Init(Context context, IAttributeSet attrs = null)
        {
            ClipToOutline = true;
            //Elevation = TypedValue.ApplyDimension(ComplexUnitType.Dip, 18, context.Resources.DisplayMetrics);

            var layoutParams = new LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            layoutParams.AddRule(LayoutRules.CenterInParent);

            _imageView = new MvxCachedImageView(context)
            {
                LayoutParameters = layoutParams
            };

            AddView(_imageView);
        }

        public void SetImageFromFilePath(string filepath)
        {
            if (_imageView != null)
            {
                _imageView.ImagePath = filepath;
            }
        }

        public void SetImageFromResource(int resourceId)
        {
            _imageView?.SetImageResource(resourceId);
        }

        public override void SetBackgroundColor(Android.Graphics.Color color)
        {
            (Background as GradientDrawable)?.SetColor(color);
        }
    }
}