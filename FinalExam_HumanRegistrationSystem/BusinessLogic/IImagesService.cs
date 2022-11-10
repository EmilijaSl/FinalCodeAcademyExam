using Domain;
using FinalExam_HumanRegistrationSystem.Dto;

namespace BusinessLogic
{
    public interface IImagesService
    {
        Task<Image> AddImageAsync(byte[] imageBytes, string contentType);
        Task<Image> GetImageAsync(int id);
        Task ChangeProfilePictureAsync(int userId, byte[] imageBytes, string contentType);
        Task<byte[]> GetImageBytesForProfilePictureChangeAsync(ImageUploadRequest imageDto);

    }
}
