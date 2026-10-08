using E.Domain.Common;




namespace E.Domain.Entites
{

    public class SocialLink : BaseEntity
    {
        public SocialPlatform Platform { get; private set; }

        public string Url { get; private set; } = null!;

        public int DisplayOrder { get; private set; }

        public bool IsActive { get; private set; }

        private SocialLink() { }

        public SocialLink(
            SocialPlatform platform,
            string url,
            int displayOrder = 0)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException(
                    "URL is required.", nameof(url));

            if (displayOrder < 0)
                throw new ArgumentException(
                    "Display order cannot be negative.",
                    nameof(displayOrder));

            Platform = platform;
            Url = url.Trim();
            DisplayOrder = displayOrder;
            IsActive = true;
        }

        public void UpdateUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException(
                    "URL is required.", nameof(url));

            Url = url.Trim();
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangeDisplayOrder(int displayOrder)
        {
            if (displayOrder < 0)
                throw new ArgumentException(
                    "Display order cannot be negative.");

            DisplayOrder = displayOrder;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }

}
