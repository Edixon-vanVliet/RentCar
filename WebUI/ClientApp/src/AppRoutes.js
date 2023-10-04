import ApiAuthorzationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { Home } from "./components/Home";
import { BrandsPage } from "./pages/Brands/BrandsPage";
import { FuelTypesPage } from "./pages/FuelType/FuelTypesPage";
import { VehicleTypesPage } from "./pages/VehicleType/VehicleTypesPage";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/brands",
    element: <BrandsPage />,
  },
  {
    path: "/fuelTypes",
    element: <FuelTypesPage />,
  },
  {
    path: "/vehicleTypes",
    element: <VehicleTypesPage />,
  },
  ...ApiAuthorzationRoutes,
];

export default AppRoutes;
