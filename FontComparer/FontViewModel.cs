using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Caliburn.Micro;

namespace FontComparer
{
    public class FontViewModel : Screen
    {
        private readonly string _location;


        public FontViewModel()
        {
            
        }

        public FontViewModel(string location)
        {
            _location = location;

            var fontFams =  Fonts.GetFontFamilies(location);
            var fontFamily = fontFams.FirstOrDefault();
            GlyphTypeface g;
            if (fontFamily != null && fontFamily.GetTypefaces().ToArray()[0].TryGetGlyphTypeface(out g))
            {
                foreach (var item in  g.CharacterToGlyphMap.OrderBy(kv => kv.Key))
                {
                    _validCharPoints.Add(new CharPointViewModel
                    {
                        Char = Char.ConvertFromUtf32(item.Value),
                        Font = fontFamily
                    });

                }
            }
            else
            {
                throw new Exception();
            }

       
        }

        public FontViewModel(string location, IEnumerable<string> charPoints)
        {
             var fontFams =  Fonts.GetFontFamilies(location);
            var fontFamily = fontFams.FirstOrDefault();
            GlyphTypeface g;
            if (fontFamily != null && fontFamily.GetTypefaces().ToArray()[0].TryGetGlyphTypeface(out g))
            {
                foreach (var item in charPoints)
                {
                    _validCharPoints.Add(new CharPointViewModel { Char = item, Font =  fontFamily});
                }
            }
            else
            {
                throw new Exception();
            }
        }
        
       ObservableCollection<CharPointViewModel> _validCharPoints = new ObservableCollection<CharPointViewModel>(); 
        public ObservableCollection<CharPointViewModel> ValidCharPoints
        {
            get
            {
                return _validCharPoints;
            }

            set
            {
                _validCharPoints = value;
                NotifyOfPropertyChange(() => ValidCharPoints);
            }
        }

        

       
            
            
    }
}
