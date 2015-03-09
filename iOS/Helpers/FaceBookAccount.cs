using QookleApp.iOS;

using Xamarin.Forms;

[assembly: Dependency(typeof(FacebookLogIn))]

namespace QookleApp.iOS
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using MonoTouch.Accounts;

    /// <summary>
    /// The face book account.
    /// </summary>
    public class FaceBookAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceBookAccount"/> class.
        /// </summary>
        public FaceBookAccount()
        {
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }
    }

    /// <summary>
    /// The facebook log in.
    /// </summary>
    public class FacebookLogIn : IFb
    {
        #region IFb implementation

        private readonly ACAccountStore accountStore = new ACAccountStore();

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookLogIn"/> class.
        /// </summary>
        public FacebookLogIn()
        {
        }

        private string Name = string.Empty;

        /// <summary>
        /// The authorize.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> Authorize()
        {
            var oAuthFBKey = string.Empty;

            var accountType = accountStore.FindAccountType(ACAccountType.Facebook);

            var a = new AccountStoreOptions();
            a.FacebookAppId = "770654556278592";
            if (await accountStore.RequestAccessAsync(accountType, a))
            {
                if (accountStore.FindAccounts(accountType).Count() == 0)
                {
                    return false;
                }

                var facebookAccount = accountStore.FindAccounts(accountType).First();
                Name = facebookAccount.UserFullName;
                oAuthFBKey = facebookAccount.Credential.OAuthToken;

                Debug.WriteLine("begin");
                Debug.WriteLine(oAuthFBKey);
                Debug.WriteLine("end");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// The get name.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetName()
        {
            return Name;
        }

        #endregion
    }
}