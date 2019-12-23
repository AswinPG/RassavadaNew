using Android.App;
using Android.Content;
using RassavadaNew.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RassavadaNew.Services
{
    public interface IMultiMediaPickerService
    {
        event EventHandler<MediaFile> OnMediaPicked;
        event EventHandler<IList<MediaFile>> OnMediaPickedCompleted;
        Task<IList<MediaFile>> PickPhotosAsync();
        Task<IList<MediaFile>> PickVideosAsync();
        void OnActivityResult(int requestCode, Result resultCode, Intent data);
        void Clean();
        
    }
}
