using DataModel.Data;

namespace DataModel.Converter
{
    public static class CpuCycleConverter
    {
        // This method was taken from here -
        // https://github.com/moby/moby/blob/eb131c5383db8cac633919f82abad86c99bffbe5/cli/command/container/stats_helpers.go#L175
        // Useful Link - https://github.com/moby/moby/issues/29306
        public static double CalculateCPUPercentWindows(DockerStatDataModel model)
        {
            long possIntervals = (model.Read - model.Preread).Milliseconds * 1000000;
            possIntervals /= 100;
            possIntervals *= model.NumProcs;

            long intervalsUsed = model.CpuStats.CpuUsage.TotalUsage - model.PrecpuStats.CpuUsage.TotalUsage;

            if (possIntervals > 0)
            {
                return (float)(intervalsUsed) / (float)(possIntervals);
            }

            return 0.00;
        }
    }
}
