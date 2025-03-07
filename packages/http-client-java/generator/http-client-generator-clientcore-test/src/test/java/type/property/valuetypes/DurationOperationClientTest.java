// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

package type.property.valuetypes;

import java.time.Duration;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.Test;

public class DurationOperationClientTest {

    private final DurationOperationClient client = new ValueTypesClientBuilder().buildDurationOperationClient();

    @Test
    public void get() {
        DurationProperty durationProperty = client.get();
        Assertions.assertEquals("PT2974H14M12.011S", durationProperty.getProperty().toString());
    }

    @Test
    @Disabled("Body provided doesn't match expected body,\"expected\":{\"property\":\"P123DT22H14M12.011S\"},\"actual\":{\"property\":\"PT2974H14M12.011S\"}")
    public void put() {
        Duration duration = Duration.parse("PT2974H14M12.011S");
        DurationProperty property = new DurationProperty(duration);
        client.put(property);
    }
}
