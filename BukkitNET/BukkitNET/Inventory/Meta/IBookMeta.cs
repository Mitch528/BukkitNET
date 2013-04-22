using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory.Meta
{
    public interface IBookMeta
    {

        bool HasTitle();

        string GetTitle();

        bool SetTitle(string title);

        bool HasAuthor();

        string GetAuthor();

        void SetAuthor(string author);

        bool HasPages();

        string GetPage(int page);

        void SetPage(int page, string data);

        List<string> GetPages();

        void SetPages(List<string> pages);

        void SetPages(params string[] pages);

        void AddPage(params string[] pages);

        int GetPageCount();

        IBookMeta Clone();

    }
}
