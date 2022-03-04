import Booker from "./pages/Booker";
import HotelManager from "./pages/HotelManager";
import Login from "./pages/Login";
import Register from "./pages/Register";
import HotelCreate from "./pages/hotelmanager/HotelCreate";
import RoomCreate from "./pages/hotelmanager/RoomCreate";
import HotelList from "./pages/hotelmanager/HotelList";
import HotelUpdate from "./pages/hotelmanager/HotelUpdate";
import HotelBrowse from "./pages/booker/HotelBrowse";
import HotelBooking from "./pages/booker/HotelBooking";
import BookingHistory from "./pages/booker/BookingHistory";
import RoomUpdate from "./pages/hotelmanager/RoomUpdate";
import Chat from "./pages/Chat";
import Overview from "./pages/hotelmanager/Overview";
import Analytics from "./pages/hotelmanager/Analytics";
import Account from "./pages/Account";


const routes = [


    {
        path: "/",
        element: <Login/>
    },
    {
        path: "register",
        element: <Register/>
    },
    {
        path: "booker",
        element: <Booker/>,
        children: [
            {
                path: '',
                element: <HotelBrowse/>
            },
            {
                path: 'reservation/hotel',
                element: <HotelBooking/>
            },
            {
                path: 'history',
                element: <BookingHistory/>
            },
            {
                path: 'chat',
                element: <Chat/>
            },
            {
                path: 'account',
                element: <Account/>
            }
        ]
    },
    {
        path: "hotelmanager",
        element: <HotelManager/>,
        children: [
            {
                path: "",
                element: <Overview/>
            },
            {
                path: "analytics",
                element: <Analytics/>
            },
            {
                path: "hotels/new",
                element: <HotelCreate/>
            },
            {
                path: "hotels/:hotelId/edit",
                element: <HotelUpdate/>
            },
            {
                path: "hotels/:hotelId/newroom",
                element: <RoomCreate/>
            },
            {
                path: "/hotelmanager/hotel/:hotelId/room/:roomId/edit",
                element: <RoomUpdate/>
            },
            {
                path: "hotels",
                element: <HotelList/>
            },
            {
                path: 'chat',
                element: <Chat/>
            },
            {
                path: 'account',
                element: <Account/>
            }
        ]
    }

]
export default routes;