using System.Diagnostics;

namespace QuantumKit.Diagnostics
{
    public static class DiagnosticsUtils
    {
        // === MODO TEMPORIZADOR SINCRÓNICO ===
        public static void RunWithTimer(Action action, string mensaje = "Ejecutando", bool showDecimals = false)
        {
            using var cts = new CancellationTokenSource();
            var token = cts.Token;

            var timerThread = new Thread(() => ShowTimer(token, mensaje, showDecimals));
            timerThread.Start();

            try
            {
                action();
            }
            finally
            {
                cts.Cancel();
                timerThread.Join();
                Console.WriteLine();
            }
        }

        // === MODO TEMPORIZADOR ASÍNCRONO ===
        public static async Task RunWithTimerAsync(Func<Task> asyncAction, string mensaje = "Ejecutando", bool showDecimals = false)
        {
            using var cts = new CancellationTokenSource();
            var token = cts.Token;

            var timerTask = Task.Run(() => ShowTimer(token, mensaje, showDecimals));

            try
            {
                await asyncAction();
            }
            finally
            {
                cts.Cancel();
                await timerTask;
                Console.WriteLine();
            }
        }

        // === MODO SPINNER (CARGA) ===
        public static void RunWithSpinner(Action action, string mensaje = "Procesando")
        {
            using var cts = new CancellationTokenSource();
            var token = cts.Token;

            var spinnerThread = new Thread(() => ShowSpinner(token, mensaje));
            spinnerThread.Start();

            try
            {
                action();
            }
            finally
            {
                cts.Cancel();
                spinnerThread.Join();
                Console.WriteLine();
            }
        }

        // === IMPLEMENTACIÓN DE TEMPORIZADOR ===
        private static void ShowTimer(CancellationToken token, string mensaje, bool showDecimals)
        {
            var stopwatch = Stopwatch.StartNew();
            string lastOutput = "";

            while (!token.IsCancellationRequested)
            {
                var t = stopwatch.Elapsed;

                string timeStr = showDecimals
                    ? $"{mensaje} [{t.Minutes:D2}:{t.Seconds:D2}.{t.Milliseconds / 10:D2}]"
                    : $"{mensaje} [{t.Minutes:D2}:{t.Seconds:D2}]";

                // Rellenamos con espacios para evitar residuos de línea anterior
                int padding = Math.Max(0, lastOutput.Length - timeStr.Length);
                lastOutput = timeStr;
                Console.Write("\r" + timeStr + new string(' ', padding));

                Thread.Sleep(showDecimals ? 50 : 250);
            }

            // Forzar una última impresión del valor final al cancelar
            var final = stopwatch.Elapsed;
            string finalStr = showDecimals
                ? $"{mensaje} [{final.Minutes:D2}:{final.Seconds:D2}.{final.Milliseconds / 10:D2}]"
                : $"{mensaje} [{final.Minutes:D2}:{final.Seconds:D2}]";

            // Relleno final para limpiar posibles residuos
            int finalPadding = Math.Max(0, lastOutput.Length - finalStr.Length);
            Console.Write("\r" + finalStr + new string(' ', finalPadding));
        }
        // === IMPLEMENTACIÓN DE SPINNER ===
        private static void ShowSpinner(CancellationToken token, string mensaje)
        {
            var chars = new[] { '-', '\\', '|', '/' };
            int index = 0;

            while (!token.IsCancellationRequested)
            {
                Console.Write($"\r{mensaje} {chars[index++ % chars.Length]}   ");
                Thread.Sleep(200);
            }
        }

        public class StopwatchLogger
        {
            private readonly Stopwatch _stopwatch;
            private readonly string _label;

            public StopwatchLogger(string label = "Duración total")
            {
                _stopwatch = Stopwatch.StartNew();
                _label = label;
            }

            public void StopAndReport(bool showDecimals = false)
            {
                _stopwatch.Stop();
                var t = _stopwatch.Elapsed;

                string timeStr = showDecimals
                    ? $"{t.Minutes:D2}:{t.Seconds:D2}.{t.Milliseconds / 10:D2}"
                    : $"{t.Minutes:D2}:{t.Seconds:D2}";

                Console.WriteLine($"\n{_label}: {timeStr}\n");
            }
        }
    }
}
