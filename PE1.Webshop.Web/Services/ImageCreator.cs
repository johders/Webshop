namespace PE1.Webshop.Web.Services
{
	public static class ImageCreator
	{

		public static async void CreateImageFile(IFormFile file)
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images", file.FileName);
			using (var stream = new FileStream(path, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
		}

	}
}
