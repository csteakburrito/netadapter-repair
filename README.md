# netadapter-repair
NetAdapter Repair allows you to effectively troubleshoot and repair common problems with windows network adapters without using command line. Was developed as a way to diagnose remote systems by walking someone through troubleshooting without using command line. It is effective for removing proxies, resetting TCP/IP stack and clearing other common windows networking issues.

## Run
```sh
Download "latest_build.zip" Open as an Administrator (Right click Run As Administrator or Shift Click Open as an Elevated User)
```
> Note: Tested Windows Versions XP, Vista, 7, 8 and 8.1, 10, 2003, 2008, 2008 R2, 2012, 2012 R2

## Features
- Advanced Repair (WinSock/TCP IP Repair, Clear all Proxy/VPN Settings, Windows Firewall Repair) <Note: Restart Needed to Complete Repair>
- Release and Renew DHCP Address
- Clear Host File
- Clear Static IP Settings (enable DHCP)
- Change to Google DNS
- Flush DNS Cache
- Clear ARP/Route Table (Restart Needed to Complete the Reset Process)
- NetBIOS Reload and Release
- Internet Options - Clear SSL State
- Enable LAN Adapters
- Enable Wireless Adapters
- Reset Internet Options Security/Privacy
- Set Network Windows Services Default (Restart Needed to Complete Repair)
- Host File View Option
- Automatic Restart Timer for the Restart Prompts (60 Seconds)
- When you clear the host file a backup of it will be saved to the log file
- Clear Static IP Settings and Change to Google DNS this can be applied to one adapter specifically or all network adapters
- Ability to select multiple instances to run at once with Run All Selected
- Public IP Address (retrieved from http://checkip.dyndns.org/)
- Computer Local hostname
- Local Private IP Address
- Current MAC Address
- Default Gateway
- DNS Servers
- DHCP Server
- Subnet Mask
- Refresh Button
- Ability to Select Another Network Adapter
- Spoofing for the Current MAC Address
- Ping Public IP Addresses (Google and Cloudflare)
- Ping Public DNS Addresses (Google and Cloudflare)
- Program Output to Logs (Will Display OS, Repairs/Options Run, Processes Loaded, Failed or Succeeded Repairs, ect.)
- Program Log File Will Be Created in Same Directory where you have Run the Program (Will Have OS, Repairs/Options Run, Processes Loaded, Failed or Succeeded Repairs, ect.)
- ipconfig output will automatically save to the log file
- Active Network Adapter Traffic Monitor with Total and Active Traffic
- Ability to Clear the Program Output Log and Traffic Monitor (This Will Not Clear the Program Log File)

| Alternative Download Locations | Link |
| ------ | ------ |
| SourceForge | https://sourceforge.net/projects/netadapter |
| SourceForge | http://www.majorgeeks.com/files/details/netadapter_repair.html |
| SourceForge | http://www.bleepingcomputer.com/download/netadapter-repair-all-in-one |

## License
MIT

The software is provided "AS IS" without any warranty. The author will not be liable for any special, incidental, consequential or indirect damages due to loss of data/corruption or any other repair malfunction.
