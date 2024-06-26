﻿using CommunityToolkit.Mvvm.Input;
using GyroShell.Library.Services.Environment;
using GyroShell.Library.Services.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

using static GyroShell.Library.Helpers.Win32.Win32Interop;

namespace GyroShell.Library.Commands
{
    public partial class StartFlyoutCommands
    {
        private readonly IEnvironmentInfoService m_envService;
        private readonly IInternalLauncher m_internalLauncher;

        public StartFlyoutCommands(IEnvironmentInfoService envService, IInternalLauncher internalLauncher)
        {
            m_envService = envService;
            m_internalLauncher = internalLauncher;
        }

        [RelayCommand]
        public void OpenShellSettings()
        {
            m_envService.SettingsInstances++;
            m_internalLauncher.LaunchShellSettings();
        }

        [RelayCommand]
        public void RestartGyroShell()
        {
            m_internalLauncher.LaunchNewShellInstance();
        }

        [RelayCommand]
        public void ExitGyroShell()
        {
            m_internalLauncher.ExitGyroShell();
        }

        [RelayCommand]
        public void LaunchTaskManager()
        {
            m_internalLauncher.LaunchProcess("taskmgr.exe", false, true);
        }

        [RelayCommand]
        public async Task LaunchWindowsSettings()
        {
            await Launcher.LaunchUriAsync(new Uri("ms-settings:"));
        }

        [RelayCommand]
        public void LaunchWindowsExplorer()
        {
            Process.Start("explorer.exe");
        }

        [RelayCommand]
        public void LaunchRunDialog()
        {
            Process.Start("explorer.exe", "shell:::{2559a1f3-21d7-11d4-bdaf-00c04f60b9f0}");
        }

        [RelayCommand]
        public void SignOutWindows()
        {
            ExitWindowsEx(EWX_LOGOFF, 0);
        }

        [RelayCommand]
        public void SleepWindows()
        {
            SetSuspendState(false, false, false);
        }

        [RelayCommand]
        public void ShutdownWindows()
        {
            m_internalLauncher.LaunchProcess("shutdown /s /t 00", false, true);
        }

        [RelayCommand]
        public void RestartWindows()
        {
            m_internalLauncher.LaunchProcess("shutdown /r /t 00", false, true);
        }

        [RelayCommand]
        public void ShowDesktop()
        {
            // TODO: Implement.
        }
    }
}
