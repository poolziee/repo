import ChartSquareBarIcon from '../../icons/ChartSquareBar';
import ChatAltIcon from '../../icons/ChatAlt';
import FolderOpenIcon from '../../icons/FolderOpen';
import ChartPieIcon from '../../icons/ChartPie';
import UserIcon from '../../icons/User';
import ReceiptIcon from '@material-ui/icons/Receipt';

const SidebarSections = (role) => {


    if (role === "ROLE_HOTEL_MANAGER") {

        return [
            {
                title: 'General',
                items: [
                    {
                        title: 'Overview',
                        path: '/hotelmanager',
                        icon: <ChartSquareBarIcon fontSize="small"/>
                    },
                    {
                        title: 'Analytics',
                        path: '/hotelmanager/analytics',
                        icon: <ChartPieIcon fontSize="small"/>
                    },
                    {
                        title: 'Account',
                        path: '/hotelmanager/account',
                        icon: <UserIcon fontSize="small"/>
                    }
                ]
            },
            {
                title: 'Management',
                items: [
                    {
                        title: 'Hotels',
                        icon: <FolderOpenIcon fontSize="small"/>,
                        path: '/hotelmanager/hotels',
                        children: [
                            {
                                title: 'Create',
                                path: '/hotelmanager/hotels/new'
                            },
                            {
                                title: 'List',
                                path: '/hotelmanager/hotels'
                            }
                        ]
                    },
                    {
                        title: 'Bookings History',
                        path: '/hotelmanager/bookingshistory',
                        icon: <ReceiptIcon fontSize="small"/>,
                    },
                ]
            },
            {
                title: 'Social',
                items: [
                    {
                        title: 'Chat',
                        path: '/hotelmanager/chat',
                        icon: <ChatAltIcon fontSize="small"/>
                    },
                ]
            }
        ];

    } else if (role === "ROLE_BOOKER") {
        return [
            {
                title: 'Account',
                items: [
                    {
                        title: 'Account',
                        path: '/booker/account',
                        icon: <UserIcon fontSize="small"/>
                    }
                ],
            },
            {
                title: 'Stays',
                items: [
                    {
                        title: 'Search',
                        path: '/booker'
                    },
                    {
                        title: 'History',
                        path: '/booker/history'
                    }
                ]
            },
            {
                title: 'Social',
                items: [
                    {
                        title: 'Chat',
                        path: '/booker/chat',
                        icon: <ChatAltIcon fontSize="small"/>
                    },
                ]
            }
        ]

    }

}
export default SidebarSections;