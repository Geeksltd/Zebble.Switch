namespace Zebble
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class Switch : View, FormField.IControl
    {
        bool @checked, IsToggling;

        public readonly AsyncEvent CheckedChanged = new AsyncEvent(ConcurrentEventRaisePolicy.Queue);
        public readonly Canvas Bar = new Canvas { Id = "Bar" };
        public readonly Canvas Toggle = new Canvas { Id = "Toggle" };

        public Alignment Alignment = Alignment.Right;

        public Switch()
        {
            CheckedChanged.Handle(UpdateCheckedState);
            Toggle.PreRendered.HandleWith(PositionToggle);
        }

        public bool Checked
        {
            get => @checked;
            set
            {
                if (@checked == value) return;
                @checked = value;
                CheckedChanged.Raise();
            }
        }

        async Task UpdateCheckedState()
        {
            await SetPseudoCssState("checked", Checked);

            if (IsRendered()) await Toggle.Animate(AnimationDuration, x => PositionToggle());
        }

        void PositionToggle()
        {
            if (Checked)
                Toggle.X(ActualWidth - (Toggle.ActualWidth + Toggle.Margin.Right()));
            else
                Toggle.X(Toggle.Margin.Left());
        }

        public TimeSpan AnimationDuration { get; set; } = Animation.DefaultSwitchDuration;

        public override async Task OnInitializing()
        {
            await base.OnInitializing();

            Tapped.Handle(ToggleChanged);
            Swiped.Handle(ToggleChanged);
            PanFinished.Handle(ToggleChanged);

            await Add(Bar);
            await Add(Toggle);
        }

        public async Task ToggleChanged()
        {
            if (IsToggling) return;
            else IsToggling = true;
            try
            {
                @checked = !@checked;
                await CheckedChanged.Raise();
            }
            finally
            {
                IsToggling = false;
            }
        }

        public override async Task OnPreRender()
        {
            await base.OnPreRender();

            if (Margin.Left() == 0)
            {
                DoAlign();
                parent.Width.Changed.HandleWith(DoAlign);
            }
        }

        void DoAlign()
        {
            if (Alignment == Alignment.Right)
            {
                var used = CurrentSiblings.Sum(c => c.CalculateTotalWidth()) + ActualWidth + Margin.Right();
                Css.Margin.Left = parent.ActualWidth - parent.Padding.Horizontal() - used;
            }
        }

        object FormField.IControl.Value
        {
            get => Checked;
            set => Checked = value.ToStringOrEmpty().ToLowerOrEmpty() == "true";
        }

        public override void Dispose()
        {
            CheckedChanged?.Dispose();
            base.Dispose();
        }
    }
}