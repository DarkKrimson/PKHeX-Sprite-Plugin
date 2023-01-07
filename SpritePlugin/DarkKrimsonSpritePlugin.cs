using System;
using System.Windows.Forms;
using PKHeX.Core;
using System.Reflection;
using System.Resources;
using System.IO;

namespace DarkKrimsonSpritePack
{
    public class DarkKrimsonSpritePlugin : IPlugin
    {
        public string Name => nameof(DarkKrimsonSpritePlugin);
        public int Priority => 1;

        public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
        public IPKMView PKMEditor { get; private set; } = null!;

        public void Initialize(params object[] args)
        {
            Console.WriteLine($"Loading {Name}...");
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            PKMEditor = (IPKMView)Array.Find(args, z => z is IPKMView);

            var PokeSpriteResources = Assembly.Load("PKHeX.Drawing.PokeSprite").GetType("PKHeX.Drawing.PokeSprite.Properties.Resources");
            var resourceMan_f = PokeSpriteResources.GetField("resourceMan", BindingFlags.NonPublic | BindingFlags.Static);

            // Load the embedded resource
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("DarkKrimsonSpritePlugin.PokeSprite.resources"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    ms.Position = 0;

                    // Save the stream to a file
                    using (FileStream file = File.Create("PokeSprite.resources"))
                    {
                        ms.CopyTo(file);
                    }

                    // Use the file as the resource
                    resourceMan_f.SetValue(null, ResourceManager.CreateFileBasedResourceManager("PokeSprite", "PokeSprite.resources", null));
                }
            }

            var ParentForm = ((ContainerControl)SaveFileEditor).ParentForm;
            ParentForm.GetType().GetMethod("PKME_Tabs_UpdatePreviewSprite", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(ParentForm, new object[] { new object(), EventArgs.Empty });
        }

        public void NotifySaveLoaded() { }

        public bool TryLoadFile(string filePath) { return false; }
    }
}