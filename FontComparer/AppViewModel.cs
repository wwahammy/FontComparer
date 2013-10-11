using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Caliburn.Micro;
using NDragDrop;

namespace FontComparer
{
    public class AppViewModel : PropertyChangedBase
    {
        
        private FontViewModel _sourceFont;
        public FontViewModel SourceFont
        {
            get
            {
                return _sourceFont;
            }
            set
            {
                if (value != _sourceFont)
                {
                    _sourceFont = value;
                    NotifyOfPropertyChange(() => SourceFont);
                    NotifyOfPropertyChange(() => CharactersToShow);
                }
            }
        }

        private FontViewModel _testFont;
        public FontViewModel TestFont
        {
            get
            {
                return _testFont;
            }
            set
            {
                if (value != _testFont)
                {
                    _testFont = value;
                    NotifyOfPropertyChange(() => TestFont);
                }
            }
        }

        public ICommand DropSource
        {
            get
            {
                return new DelegateCommand<DropEventArgs>(args =>
                {
                    var dropList = args.Context as IEnumerable<string>;
                    if (dropList == null || !dropList.Any()) return;

                    SourceFont = new FontViewModel(dropList.First());
                });
            }
        }

        public ICommand DropTest
        {
            get
            {
                return new DelegateCommand<DropEventArgs>(args =>
                {
                    var dropList = args.Context as IEnumerable<string>;
                    if (dropList == null || !dropList.Any()) return;

                    TestFont = new FontViewModel(dropList.First(), CharactersToShow);
                });
            }
        }

        public IList<string> CharactersToShow
        {
            get
            {
                try
                {
                    return SourceFont.ValidCharPoints.Select(i => i.Char).ToList();
                }
                catch (Exception)
                {

                    return Enumerable.Empty<string>().ToList();
                }
                
            }
        }
        
    }
}
