using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Permissions
{
    public class PermissionAttachmentInfo
    {

        private IPermissible permissible;
        private string permission;
        private PermissionAttachment attachment;
        private bool value;

        public IPermissible Permissible
        {
            get
            {
                return permissible;
            }
        }

        public string Permission
        {
            get
            {
                return permission;
            }
        }

        public PermissionAttachment Attachment
        {
            get
            {
                return attachment;
            }
        }

        public bool Value
        {
            get
            {
                return value;
            }
        }

        public PermissionAttachmentInfo(IPermissible permissible, string permission, PermissionAttachment attachment, bool value)
        {
            if (permissible == null)
            {
                throw new ArgumentException("Permissible may not be null");
            }
            else if (permission == null)
            {
                throw new ArgumentException("Permissions may not be null");
            }

            this.permissible = permissible;
            this.permission = permission;
            this.attachment = attachment;
            this.value = value;
        }

    }
}
