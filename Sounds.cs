using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace L5055215.MyMethods
{
    public class Sounds
    {
        private string soundBeep = @"sounds\Beep.wav";
        private string soundFinished = @"sounds\Finshed.wav";
        private string soundNewForm = @"sounds\NewForm.wav";
        private string soundTheme = @"sounds\theme.wav";
        private string passwordGood = @"sounds\passwordGood.wav";

        public void playPasswordGood()
        {
           SoundPlayer simpleSound = new SoundPlayer(passwordGood);
           simpleSound.Play();
        }

        public void playTheme()
        {
            SoundPlayer Sound = new SoundPlayer(soundTheme);
            Sound.Play();
        }

        public void playBeep() {
            SoundPlayer simpleSound = new SoundPlayer(soundBeep);
            simpleSound.Play();
        }


        public void playFinished()
        {
            SoundPlayer simpleSound = new SoundPlayer(soundFinished);
            simpleSound.Play();
        }


        public void playNewForm()
        {
            SoundPlayer simpleSound = new SoundPlayer(soundNewForm);
            simpleSound.Play();
        }

    }
}
