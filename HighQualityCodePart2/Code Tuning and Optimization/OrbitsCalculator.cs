using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace SolarSystem
{
	class OrbitsCalculator : INotifyPropertyChanged
	{
		const double EarthYear = 365.25;
		const double EarthRotationPeriod = 1.0;
		const double SunRotationPeriod = 25.0;
		const double TwoPi = Math.PI * 2;

		private DateTime startTime;
		private DispatcherTimer timer;
		private double daysPerSecond;

		public event PropertyChangedEventHandler PropertyChanged;

		public OrbitsCalculator()
		{
			EarthOrbitPositionX = EarthOrbitRadius;
			DaysPerSecond = 2;
		}

		public double DaysPerSecond
		{
			get
			{
				return this.daysPerSecond;
			}
			set
			{
				this.daysPerSecond = value;
				Update("DaysPerSecond");
			}
		}

		public double EarthOrbitRadius
		{
			get
			{
				return 40;
			}
		}

		public double Days { get; set; }
		public double EarthRotationAngle { get; set; }
		public double SunRotationAngle { get; set; }
		public double EarthOrbitPositionX { get; set; }
		public double EarthOrbitPositionY { get; set; }
		public double EarthOrbitPositionZ { get; set; }
		public bool ReverseTime { get; set; }

		public void StartTimer()
		{
			startTime = DateTime.Now;
			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromMilliseconds(10);
			timer.Tick += new EventHandler(OnTimerTick);
			timer.Start();
		}

		private void StopTimer()
		{
			timer.Stop();
			timer.Tick -= OnTimerTick;
			timer = null;
		}

		public void Pause(bool doPause)
		{ 
			if (doPause)
			{
				StopTimer();
			}
			else
			{
				StartTimer();
			}
		}

		private void OnTimerTick(object sender, EventArgs e)
		{
			var now = DateTime.Now;
			var milisec = (now - startTime).TotalMilliseconds;
			var time = (ReverseTime ? -1 : 1);
			var updateDays = (milisec * DaysPerSecond / 1000.0 * time);
			Days += updateDays;
			startTime = now;
			Update("Days");
			EarthPosition();
			EarthRotation();
			SunRotation();
		}

		private void EarthPosition()
		{
			double angle = TwoPi * Days / EarthYear;
			EarthOrbitPositionX = EarthOrbitRadius * Math.Cos(angle);
			EarthOrbitPositionY = EarthOrbitRadius * Math.Sin(angle);
			Update("EarthOrbitPositionX");
			Update("EarthOrbitPositionY");
		}

		private void EarthRotation()
		{
			var updateStep = 0.00005;

			for (double step = 0; step <= 360; step+=updateStep)
			{
				EarthRotationAngle = step * Days / EarthRotationPeriod;
			}
			Update("EarthRotationAngle");
		}

		private void SunRotation()
		{
			SunRotationAngle = 360 * Days / SunRotationPeriod;
			Update("SunRotationAngle");
		}

		private void Update(string propertyName)
		{
			if (PropertyChanged != null)
			{
				var args = new PropertyChangedEventArgs(propertyName);
				PropertyChanged(this, args);
			}
		}
	}
}
