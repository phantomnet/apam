namespace apam.Models
{
    public class TrackItem
    {
        public int Index { get; }
        public string Title { get; }
        public string SubTitle { get; }
        public string Link { get; }
        public string Thumb { get; }

        public TrackItem()
        {
            Index = 0;
            Title = "";
            SubTitle = "";
            Link = "";
            Thumb = "";
        }

        public TrackItem(int index, string title, string subtitle, string link, string thumb)
        {
            Index = index;
            Title = title;
            SubTitle = subtitle;
            Link = link;
            Thumb = thumb;
        }
    }
}
