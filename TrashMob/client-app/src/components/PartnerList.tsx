import * as React from 'react'
import { RouteComponentProps, useHistory } from 'react-router-dom';
import UserData from './Models/UserData';
import { Button } from 'react-bootstrap';
import PartnerData from './Models/PartnerData';

class DisplayPartner {
    id: string = "";
    name: string = "";
}


export interface PartnerListDataProps extends RouteComponentProps {
    partnerList: PartnerData[];
    isPartnerDataLoaded: boolean;
    isUserLoaded: boolean;
    currentUser: UserData;
    onPartnerLocationsChanged: any;
};

export const PartnerList: React.FC<PartnerListDataProps> = (props) => {
    const [displayPartners, setDisplayPartners] = React.useState<DisplayPartner[]>([]);
    const history = useHistory();

    React.useEffect(() => {
        if (props.isPartnerDataLoaded && props.partnerList) {
            const list = props.partnerList.map((partner) => {
                var dispPartner = new DisplayPartner()
                dispPartner.id = partner.id;
                dispPartner.name = partner.name;
               return dispPartner;
            });
            setDisplayPartners(list);
        }
    }, [props.isPartnerDataLoaded, props.partnerList, props.isUserLoaded])

    function renderPartnersTable(partners: DisplayPartner[]) {
        return (
            <div>
                <table className='table table-striped' aria-labelledby="tabelLabel" width='100%'>
                    <thead>
                        <tr>
                            <th>Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {partners.map(partner =>
                            <tr key={partner.id.toString()}>
                                <td>{partner.name}</td>
                                <td>
                                    <Button className="action" onClick={() => history.push('/partnerDetails/' + partner.id)}>View Details</Button>
                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    return (
        <>
            <div>
                {!props.isPartnerDataLoaded && <p><em>Loading...</em></p>}
                {props.isPartnerDataLoaded && renderPartnersTable(displayPartners)}
            </div>
        </>
    );
}